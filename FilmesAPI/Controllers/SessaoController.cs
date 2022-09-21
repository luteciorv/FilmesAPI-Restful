using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.DTOS;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessaoController : ControllerBase
    {
        private readonly APIContext _context;
        private readonly IMapper _mapper;

        public SessaoController(APIContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionarSessao([FromBody] CriarSessaoDTO sessaoDTO)
        {
            var sessao = _mapper.Map<Sessao>(sessaoDTO);

            _context.Sessoes.Add(sessao);
            _context.SaveChanges();

            return CreatedAtAction(nameof(RecuperarSessaoPeloID), new { sessao.ID }, sessao);
        }


        [HttpGet("{id}")]
        public IActionResult RecuperarSessaoPeloID(int id)
        {
            var sessao = _context.Sessoes.Find(id);

            if(sessao == null)
            {
                return NotFound();
            }

            var sessaoDTO = _mapper.Map<LerSessaoDTO>(sessao);
            return Ok(sessaoDTO);
        }
    }
}