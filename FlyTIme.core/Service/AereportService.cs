public class AereportService
{
    private readonly IAereportRepository _AereportRepository;

    public AereportService(IAereportRepository AereportRepository)
    {
        _AereportRepository = AereportRepository;
    }

}