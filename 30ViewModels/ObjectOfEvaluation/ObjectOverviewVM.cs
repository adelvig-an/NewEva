﻿using NewEva.VM.ObjectOfEvaluation.Flat;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewEva.VM.ObjectOfEvaluation
{
    public class ObjectOverviewVM : PageVM
    {
        private PageVM currentPage;
        private string[] pages;
        private int currentIndex;
        public PageVM CurrentPage
        {
            get => currentPage;
            set
            {
                currentPage?.WriteCBOR();
                SetProperty(ref currentPage, value);
            }
        }
        public string[] Pages
        {
            get => pages;
            set
            {
                SetProperty(ref pages, value);
            }
        }
        public int CurrentIndex
        {
            get => currentIndex;
            set
            {
                CurrentPage = CreatePageByName(pages[value]);
                SetProperty(ref currentIndex, value);
            }
        }
        public PageVM CreatePageByName(string pageName)
        {
            if (pageName == "FlatLocationVM")
                return new FlatLocationVM();
            else if (pageName == "FlatDescriptionVM")
                return new FlatDescriptionVM();
            else if (pageName == "FlatCalculationVM")
                return new FlatCalculationVM();
            else if (pageName == "ObjectDocAndPhotoVM")
                return new ObjectDocAndPhotoVM();
            else
                return null;
        }

        public override byte[] GetCBOR()
        {
            return null;
        }

        public override void SetCBOR(byte[] b)
        {
            
        }

        public ObjectOverviewVM()
        {
            pages = new string[]
            {
                "FlatLocationVM",
                "FlatDescriptionVM",
                "FlatCalculationVM",
                "ObjectDocAndPhotoVM"
            };
            CurrentIndex = 0;
        }
    }
}
