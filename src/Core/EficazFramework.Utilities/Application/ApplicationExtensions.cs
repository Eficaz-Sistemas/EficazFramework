namespace EficazFramework.Application;

public static class ApplicationExtensions
{
    /// <summary>
    /// Retorna se um aplicativo está em execução atualmente.
    /// </summary>
    /// <param name="application">Instância de aplicativo a ser verificado.</param>
    /// <returns></returns>
    public static bool IsRunning(this ApplicationDefinition application)
        => IApplicationManager.Instance.IsRunning(application);


    /// <summary>
    /// Ativa uma aplicação para trabalho. Caso ainda não esteja em execução, uma nova intância é criada.
    /// </summary>
    /// <param name="application">Manifesto de aplicativo a ser iniciado ou ativado.</param>
    public static void Activate(this ApplicationDefinition application)
    {
        IApplicationManager.Instance.Activate(application);
    }

}
