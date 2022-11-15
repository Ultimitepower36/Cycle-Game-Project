using System.Collections.Generic;
using Unit05.Game.Casting;
using Unit05.Game.Services;


namespace Unit05.Game.Scripting
{
    /// <summary>
    /// <para>An output action that draws all the actors.</para>
    /// <para>The responsibility of DrawActorsAction is to draw each of the actors.</para>
    /// </summary>
    public class DrawActorsAction : Action
    {
        private VideoService videoService;

        /// <summary>
        /// Constructs a new instance of ControlActorsAction using the given KeyboardService.
        /// </summary>
        public DrawActorsAction(VideoService videoService)
        {
            this.videoService = videoService;
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            Snake Player1 = (Snake)cast.GetFirstActor("Player1");
            List<Actor> segments1 = Player1.GetSegments();
            Snake Player2 = (Snake)cast.GetFirstActor("Player2");
            List<Actor> segments2 = Player2.GetSegments();
            Actor score = cast.GetFirstActor("score");
            List<Actor> messages = cast.GetActors("messages");
            
            videoService.ClearBuffer();
            videoService.DrawActors(segments1);
            videoService.DrawActors(segments2);
            videoService.DrawActor(score);
            videoService.DrawActors(messages);
            videoService.FlushBuffer();
        }
    }
}