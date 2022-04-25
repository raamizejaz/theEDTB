using System;

namespace theEDTB.Models
{
    public class Item
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }

        public string Identifier { get; set; }

        public string DeviceNmae { get; set; }
    }
    public class DeviceModel
    {
        public string Identifier { get; set; }
        public string DeviceNmae { get; set; }
    }
}