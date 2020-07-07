namespace meucaixa.DependencyServices
{
    public interface ISnackbarService
    {
        void MostraSnackbarLongo(string mensagem);
        void MostraSnackbarCurto(string mensagem);
    }
}
