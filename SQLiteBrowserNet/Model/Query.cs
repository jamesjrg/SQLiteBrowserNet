﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SQLiteBrowserNet.Model
{
    class Query
    {
        public string Filename { get; set; }
        public string FilePath { get; set; }
        public string Text { get; set; }
        public bool IsModified { get; set; }
        
        static int newQueryCounter = 1;

        public Query()
        {
            Filename = "newQuery" + newQueryCounter;
            newQueryCounter++;
        }
    }
}
