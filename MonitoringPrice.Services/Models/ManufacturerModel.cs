namespace MonitoringPrice.Services.Models
{
    public  class ManufacturerModel
    {
        /// <summary> Id </summary>
        public int Id { get; set; }

        /// <summary>Наименование производителя </summary>
        public string ManufacturerName { get; set; } = null!;
    }
}