﻿using Microsoft.WindowsAzure.Storage.Table;

namespace AzureFunctions.Api.Model
{
    public class Project : TableEntity
    {
        public string ProjectId { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }

    }
}
