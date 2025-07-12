namespace RestaurantManagementApp.Extension.Mapping.Queue;

public static class QueueMapper
{
    public static TblQueue ToEntity(this CreateQueueDto dataModal)
    {
        return new TblQueue
        {
            CustomerName = dataModal.CustomerName,
            PhoneNumber = dataModal.PhoneNumber,
            NumberofPeople = dataModal.NumberofPeople,
            QueueStatus = QueueStatus.InLine.Name,
            CreatedAt = DateTime.UtcNow
        };
    }

    public static QueueDto ToDto(this TblQueue dataModal)
    {
        return new QueueDto
        {
            QueueId = dataModal.Id,
            CustomerName = dataModal.CustomerName,
            PhoneNumber = dataModal.PhoneNumber,
            NumberofPeople = dataModal.NumberofPeople,
            QueueStatus = dataModal.QueueStatus
        };
    }

    public static TblQueue ToEntity(this UpdateQueueDto dataModal, TblQueue existingEntity)
    {
        return new TblQueue
        {
            CustomerName = dataModal.CustomerName,
            PhoneNumber = dataModal.PhoneNumber,
            NumberofPeople = dataModal.NumberofPeople,
            QueueStatus = dataModal.QueueStatus,
            UpdatedAt = DateTime.UtcNow
        };
    }
}