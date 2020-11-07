﻿using System;
using System.Windows;
/// <summary>
/// The drag and drop box view model.
/// </summary>
namespace bg3_mod_packer.ViewModels
{
    public class DragAndDropBox : BaseViewModel
    {
        public DragAndDropBox()
        {
            PackAllowed = !string.IsNullOrEmpty(Properties.Settings.Default.divineExe);
        }

        public void ProcessDrop(IDataObject data)
        {
            Services.DragAndDropHelper.ProcessDrop(data);
            Lighten();
        }

        internal void Darken()
        {
            PackBoxColor = PackAllowed ? "LightGreen" : "MidnightBlue";
            DescriptionColor = PackAllowed ? "Black" : "White";
        }

        internal void Lighten()
        {
            PackBoxColor = "LightBlue";
            DescriptionColor = "Black";
        }

        #region Properties
        private string _packBoxColor;

        public string PackBoxColor {
            get { return _packBoxColor; }
            set {
                _packBoxColor = value;
                OnNotifyPropertyChanged();
            }
        }

        private string _descriptionColor;

        public string DescriptionColor {
            get { return _descriptionColor; }
            set {
                _descriptionColor = value;
                OnNotifyPropertyChanged();
            }
        }

        private bool _packAllowed;

        public bool PackAllowed {
            get { return _packAllowed; }
            set {
                _packAllowed = value;
                if (value)
                    Lighten();
                else
                    Darken();
                PackBoxInstructions = value ? "Drop mod workspace folder here" : "Select divine.exe location";
                OnNotifyPropertyChanged();
            }
        }

        private string _packBoxInstructions;

        public string PackBoxInstructions {
            get { return _packBoxInstructions; }
            set {
                _packBoxInstructions = value;
                OnNotifyPropertyChanged();
            }
        }
        #endregion
    }
}
