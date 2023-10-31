namespace TesteUGB.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public int MatriculaUsuario { get; set; }
        public string NomeCompletoUsuario { get; set; }
        public string EmailUsuario { get; set; }
        public string UsuarioLogin { get; set; }
        public string DepartamentoFuncionario { get; set; }
        //public string Senha { get; set; }
        //public PerfilEnum Perfil { get; set; }

        //public bool SenhaValida(string senha)
        //{
        //    return Senha == senha;
        //}

        //public void SetSenhaHash()
        //{
        //    Senha = Senha.GerarHash();
        //}
        //public void SetNovaSenha(string novaSenha)
        //{
        //    Senha = novaSenha.GerarHash();
        //}
        //public string GerarNovaSenha()
        //{
        //    string novaSenha = Guid.NewGuid().ToString().Substring(0, 8);
        //    Senha = novaSenha.GerarHash();
        //    return novaSenha;
        //}
    }
}
