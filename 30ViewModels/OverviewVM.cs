﻿using NewEva.VM.ObjectOfEvaluation;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewEva.VM
{
    public class OverviewVM : PageVM
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
            if (pageName == "ReportVM")
                return new ReportVM();
            else if (pageName == "ObjectOverviewVM")
                return new ObjectOverviewVM();
            else
                return null;
        }
        public OverviewVM()
        {
            pages = new string[]
            {
                "ReportVM",
                "ObjectOverviewVM"
            };
            CurrentIndex = 0;
        }

        public override byte[] GetCBOR()
        {
            throw new NotImplementedException();
        }
        public override void SetCBOR(byte[] b)
        {
            throw new NotImplementedException();
        }
    }
}
