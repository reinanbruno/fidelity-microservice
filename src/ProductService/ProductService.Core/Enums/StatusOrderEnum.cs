namespace ProductService.Core.Enums
{
    public enum StatusOrderEnum
    {
        PreparingProduct = 'P',
        OutForDelivery = 'O',
        InTrafic = 'T',
        Delivered = 'D',
        DeliveredNotMade = 'N',
        CanceledByUser = 'U'
    }
}
