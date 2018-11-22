using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ChitChat.Models;

namespace ChitChat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly ChitChatContext _context;

        public PostController(ChitChatContext context)
        {
            _context = context;
        }

        // GET: api/Post
        [HttpGet]
        public IEnumerable<PostItem> GetPostItem()
        {
            return _context.PostItem;
        }

        // GET: api/Post/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPostItem([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var postItem = await _context.PostItem.FindAsync(id);

            if (postItem == null)
            {
                return NotFound();
            }

            return Ok(postItem);
        }

        // PUT: api/Post/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPostItem([FromRoute] int id, [FromBody] PostItem postItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != postItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(postItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Post
        [HttpPost]
        public async Task<IActionResult> PostPostItem([FromBody] PostItem postItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PostItem.Add(postItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPostItem", new { id = postItem.Id }, postItem);
        }

        // DELETE: api/Post/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePostItem([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var postItem = await _context.PostItem.FindAsync(id);
            if (postItem == null)
            {
                return NotFound();
            }

            _context.PostItem.Remove(postItem);
            await _context.SaveChangesAsync();

            return Ok(postItem);
        }

        private bool PostItemExists(int id)
        {
            return _context.PostItem.Any(e => e.Id == id);
        }

        // GET: api/Meme/Title
        [Route("msgs")]
        [HttpGet]
        public async Task<List<string>> GetMsgs()
        {
            var memes = (from m in _context.PostItem
                         select m.Msg).Distinct();

            var returned = await memes.ToListAsync();

            return returned;
        }


        // GET: api/Meme/Tags

        [HttpGet]
        [Route("msg")]
        public async Task<List<PostItem>> GetMsgItems([FromQuery] string msgs)
        {
            var memes = from m in _context.PostItem
                        select m; //get all the posts


            if (!String.IsNullOrEmpty(msgs)) //make sure user gave a word to search
            {
                memes = memes.Where(s => s.Msg.ToLower().Contains(msgs.ToLower())); // find the entries with the word
            }

            var returned = await memes.ToListAsync(); //return the postss

            return returned;
        }
    }
}