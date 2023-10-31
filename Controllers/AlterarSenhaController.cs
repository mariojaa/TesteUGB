//using Microsoft.AspNetCore.Mvc;
//using TesteUGB.Models;
//using TesteUGB.Repositorio;

//namespace TesteUGB.Controllers
//{
//    [Route("api/alterarsenha")]
//    [ApiController]
//    public class AlterarSenhaApiController : ControllerBase
//    {
//        private readonly UsuarioRepository _usuarioRepository;

//        public AlterarSenhaApiController(UsuarioRepository usuarioRepository)
//        {
//            _usuarioRepository = usuarioRepository;
//        }

//        [HttpPost("alterar")]
//        public IActionResult Alterar(AlterarSenhaModel alterarSenhaModel)
//        {
//            try
//            {
//                if (ModelState.IsValid)
//                {
//                    _usuarioRepository.AlterarSenha(alterarSenhaModel);
//                    return Ok("Senha alterada com sucesso!");
//                }
//                return BadRequest(ModelState);
//            }
//            catch (System.Exception erro)
//            {
//                return StatusCode(500, $"Ops, {erro.Message}");
//            }
//        }
//    }
//}
