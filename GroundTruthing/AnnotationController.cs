using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GroundTruthing
{
    class AnnotationController
    {
        /**
         * Used only when we need to load a new image into the main display.
         **/
        private ImageStorage imageStorage = null;

        /**
         * The annotation that is selected in the annotation list.
         **/
        private Annotation selectedAnnotation = null;

        /**
         * The annotation collection
         **/
        private LinkedList<Annotation> annotationList = new LinkedList<Annotation>();

        /**
         * The frame array for out video.
         **/
        private AnnotationFrame[] imageFrameAnnotations = null;

        /**
         * The current index we are currently sitting at.
         **/
        private int imageFrameIndex = -1;

        /**
         * Constructor
         **/
        public AnnotationController()
        {
            
        }

        /**
         * Scroll image left
         **/
        public Image PreviouseImage()
        {
            if (!ControllerValid())
            {
                return ImageStorage.DefaultImage();
            }

            imageFrameIndex = imageFrameIndex - 1;

            if (imageFrameIndex < 0)
            {
                imageFrameIndex = 0;
            }

            return GenerateFrame(imageStorage.ReadImage(imageFrameIndex));
        }

        /**
         * Scroll image right
         **/
        public Image NextImage()
        {
            if (!ControllerValid())
            {
                return ImageStorage.DefaultImage();
            }

            if (imageFrameIndex + 1 != imageFrameAnnotations.Length)
            {
                if (imageFrameAnnotations[imageFrameIndex + 1] == null)
                {
                    imageFrameAnnotations[imageFrameIndex + 1] = new AnnotationFrame();
                }
                AnnotationFrame.CopyToNextFrameIfFree(imageFrameAnnotations[imageFrameIndex], imageFrameAnnotations[imageFrameIndex + 1]);
            }

            imageFrameIndex = imageFrameIndex + 1;

            if (imageFrameIndex >= imageFrameAnnotations.Length)
            {
                imageFrameIndex = imageFrameAnnotations.Length - 1;
            }

            return GenerateFrame(imageStorage.ReadImage(imageFrameIndex));
        }

        /**
         * Messages passed by mouse events on the main display
         **/
        public void HandleDisplayMessage(int mouseX, int mouseY, bool shiftClick, PictureBox destinationPictureBox)
        {
            // Ensure we are not being sent rubish
            if (mouseX < 0 || mouseY < 0)
            {
                return;
            }

            // Ensure a valid state
            if (!ControllerValid())
            {
                return;
            }

            // Check to see if the current image index frame is in bounds
            if (imageFrameAnnotations.Length <= imageFrameIndex)
            {
                return;
            }

            // Deal with annotation updates
            if (selectedAnnotation != null)
            {
                if (imageFrameAnnotations[imageFrameIndex] == null)
                {
                    imageFrameAnnotations[imageFrameIndex] = new AnnotationFrame();
                }

                if (shiftClick)
                {
                    imageFrameAnnotations[imageFrameIndex].UpdateBottom(selectedAnnotation, mouseX, mouseY);
                }

                else
                {
                    imageFrameAnnotations[imageFrameIndex].UpdateTop(selectedAnnotation, mouseX, mouseY);
                }

                destinationPictureBox.Image = GenerateFrame(imageStorage.ReadImage(imageFrameIndex));
                destinationPictureBox.Refresh();
            }
        }

        /**
         * Set the working directory
         **/
        public void SetWorkingDirectory()
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();

            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                imageStorage = new ImageStorage(folderBrowser.SelectedPath);

                if (!imageStorage.Scan())
                {
                    imageFrameIndex = -1;
                    imageFrameAnnotations = null;
                    selectedAnnotation = null;
                }

                else
                {
                    imageFrameIndex = 0;
                    imageFrameAnnotations = new AnnotationFrame[imageStorage.FileCount()];
                }

            }
        }

        /**
         * Read out the frame information to the tree view
         **/
        public void UpdateTreeView(TreeView destinationTreeView)
        {
            if (!ControllerValid())
            {
                return;
            }

            // Clear the tree
            destinationTreeView.Nodes.Clear();

            // Update the tree
            destinationTreeView.Nodes.Add("Current Frame = " + imageFrameIndex);
            destinationTreeView.Nodes.Add("Current Directory = " + imageStorage.GetWorkingDirectory());
        }

        /**
         * Add a new annotation to the list, generate the annotation object and add to the collection
         **/
        public void AddAnnotation(ListBox destinationListBox)
        {
            NewAnnotation annotationNameSelectorForm = new NewAnnotation();
            annotationNameSelectorForm.ShowDialog();

            if (annotationNameSelectorForm.annotationName == "")
            {
                return;
            }

            string annotationName = annotationNameSelectorForm.annotationName;

            Annotation newAnnotation = new Annotation();
            newAnnotation.name = annotationName;
            newAnnotation.color = RandomColor();

            destinationListBox.Items.Add(newAnnotation);
            annotationList.AddLast(newAnnotation);

            selectedAnnotation = newAnnotation;
            destinationListBox.SelectedItem = selectedAnnotation;
        }

        /**
         * Select annotation object, handles the selectedIndexChanged event.
         **/
        public void UpdateSelectedAnnotation(string itemText)
        {
            foreach (Annotation annotation in annotationList)
            {
                if (annotation.name == itemText)
                {
                    selectedAnnotation = annotation;
                }
            }
        }

        /**
         * Gets a random color
         **/
        public Color RandomColor()
        {
            Random randonGen = new Random();
            return Color.FromArgb(randonGen.Next(255), randonGen.Next(255), randonGen.Next(255));
        }

        /**
         * Generates an image based on the frames bounding objects
         **/
        public Image GenerateFrame(Image mainImage)
        {
            if (mainImage != null)
            {
                Image generatedImage = new Bitmap(mainImage);

                if (imageFrameAnnotations[imageFrameIndex] != null)
                {
                    // Perform correction
                    bool correctionFlag = true;
                    while (correctionFlag)
                    {
                        foreach (DictionaryEntry pair in imageFrameAnnotations[imageFrameIndex].annotationTable)
                        {
                            if (imageFrameAnnotations[imageFrameIndex].AnnotationComplete((Annotation)pair.Key))
                            {
                                if (CorrectAnnotationOrientation(imageFrameAnnotations[imageFrameIndex], (Annotation)pair.Key))
                                {
                                    break;
                                }

                                else
                                {
                                    correctionFlag = false;
                                }
                            }
                        }
                    }

                    foreach (DictionaryEntry pair in imageFrameAnnotations[imageFrameIndex].annotationTable)
                    {
                        if (imageFrameAnnotations[imageFrameIndex].AnnotationComplete((Annotation)pair.Key))
                        {
                            CorrectAnnotationOrientation(imageFrameAnnotations[imageFrameIndex], (Annotation)pair.Key);
                            DrawAnnotation(ref generatedImage, (Annotation)pair.Key, (Bounding)pair.Value);
                        }
                    }
                }

                return generatedImage;
            }

            else
            {
                return ImageStorage.DefaultImage();
            }
        }

        /**
         * Corrects top and bottom markers
         **/
        public bool CorrectAnnotationOrientation(AnnotationFrame currentFrame, Annotation currentObject)
        {
            bool flipBottomX = false;
            bool flipBottomY = false;

            Bounding targetBounding = (Bounding)currentFrame.annotationTable[currentObject];

            if (targetBounding.BottomRight_x < targetBounding.Topleft_x)
            {
                flipBottomX = true;
            }

            if (targetBounding.BottomRight_y < targetBounding.TopLeft_y)
            {
                flipBottomY = true;
            }

            if (flipBottomX && flipBottomY)
            {
                int width = targetBounding.Topleft_x - targetBounding.BottomRight_x;
                int height = targetBounding.TopLeft_y - targetBounding.BottomRight_y;
                currentFrame.annotationTable[currentObject] = CorrectBoundingBox(targetBounding.BottomRight_x, targetBounding.BottomRight_y, targetBounding.Topleft_x, targetBounding.TopLeft_y);
                return true;
            }

            else if (flipBottomX)
            {
                int real_y = targetBounding.TopLeft_y;
                int real_x = targetBounding.BottomRight_x;
                currentFrame.annotationTable[currentObject] = CorrectBoundingBox(real_x, real_y, targetBounding.Topleft_x, targetBounding.BottomRight_y);
                return true;
            }

            else if (flipBottomY)
            {
                int real_y = targetBounding.BottomRight_y;
                int real_x = targetBounding.Topleft_x;
                currentFrame.annotationTable[currentObject] = CorrectBoundingBox(real_x, real_y, targetBounding.BottomRight_x, targetBounding.TopLeft_y);
                return true;
            }

            return false;
        }

        /**
         * Draws boxes over an image
         **/
        public void DrawAnnotation(ref Image destinationImage, Annotation targetAnnotation, Bounding targetBounding)
        {
            Graphics graphicsObject = Graphics.FromImage(destinationImage);
            Rectangle annotationBox;


            int width = targetBounding.BottomRight_x - targetBounding.Topleft_x;
            int height = targetBounding.BottomRight_y - targetBounding.TopLeft_y;
            annotationBox = new Rectangle(targetBounding.Topleft_x, targetBounding.TopLeft_y, width, height);

            Pen drawingPen = new Pen(targetAnnotation.color, 2);
            graphicsObject.DrawRectangle(drawingPen, annotationBox);
            graphicsObject.Flush();
        }

        public Bounding CorrectBoundingBox(int topX, int topY, int botX, int botY)
        {
            Bounding corrected = new Bounding();
            corrected.Topleft_x = topX;
            corrected.TopLeft_y = topY;
            corrected.BottomRight_x = botX;
            corrected.BottomRight_y = botY;
            return corrected;
        }

        /**
         * Draws boxes over an image
         **/
        public void SaveCurrentCapture()
        {
            SaveData saveData = new SaveData("Temp.xml");
            saveData.Save(imageFrameAnnotations);
        }

        /**
         * Loads a previouse capture from disk
         **/
        public void LoadCapture()
        {
            
        }

        /**
         * Validate the state of the controller
         **/
        private bool ControllerValid()
        {
            // Check to see if we have a valid image store
            if (imageStorage == null)
            {
                return false;
            }

            // Check we are working with a valid frame index
            if (imageFrameAnnotations == null)
            {
                return false;
            }

            return true;
        }
    }
}
