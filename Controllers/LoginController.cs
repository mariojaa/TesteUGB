//using Microsoft.AspNetCore.Mvc;
//using TesteUGB.Helper;
//using TesteUGB.Models;
//using TesteUGB.Repositorio;
//using TesteUGB.Repository.Interface;

//namespace TesteUGB.Controllers
//{
//    [Route("api/login")]
//    [ApiController]
//    public class LoginController : ControllerBase // Usar ControllerBase em vez de Controller
//    {
//        private readonly IUsuarioRepository _usuarioRepository;
//        private readonly ISessao _sessao;
//        private readonly IEmail _email;

//        public LoginController(IUsuarioRepository usuarioRepository, ISessao sessao, IEmail email)
//        {
//            _usuarioRepository = usuarioRepository;
//            _sessao = sessao;
//            _email = email;
//        }

//        [HttpPost("entrar")]
//        public async Task<IActionResult> Entrar([FromBody] LoginModel loginModel)
//        {
//            try
//            {
//                if (ModelState.IsValid)
//                {
//                    var usuario = await _usuarioRepository.BuscarPorLogin(loginModel.Login);

//                    if (usuario != null && usuario.SenhaValida(loginModel.Senha))
//                    {
//                        _sessao.CriarSessaoUsuario(usuario);
//                        return Ok(new { Message = "Login successful" });
//                    }

//                    return BadRequest(new { Message = "Oops, incorrect username or password. Please check and try again." });
//                }

//                return BadRequest(new { Message = "Oops, invalid data. Please check and try again." });
//            }
//            catch (Exception)
//            {
//                return StatusCode(500, new { Message = "Oops, no database connection! Please wait a few minutes and try again." });
//            }
//        }
//    }
//}
