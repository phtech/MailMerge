﻿namespace MailMerge.OoXml.Properties
{
    public class Settings
    {
        public int MaximumOutputFileSize { get; set; } = 100*1000*1000;
        public int MaximumMemoryStreamSize { get; set; } = 10 * 1000 * 1000;
        public string  TenantId { get; set; }
        public decimal OutputHeadroomFactor { get; set; } = 1.2m;
    }
}
