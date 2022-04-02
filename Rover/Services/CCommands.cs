using System;
using Microsoft.Extensions.Logging;
using Rover.Controllers;

namespace Rover.Services
{
    public class CCommands : ICommands
    {
        private int _x, _y;
        private char _direction;
        private int _xMax;
        private int _yMax;

        private readonly ILogger<MainController> _logger;

        public CCommands(ILogger<MainController> logger)
        {
            _logger = logger;
        }
        public void Init( int x0, int y0, char dir0, int xMax, int yMax)
        {
            _x = x0;
            _y = y0;
            _direction = dir0;
            this._xMax = xMax;
            this._yMax = yMax;
        }

        public int Execute(char[] commands)
        {
            int obstacles = 0;
            foreach (var command in commands)
            {
                switch (command)
                {
                   case 'F': obstacles = MoveForward(); break; 
                   case 'B': obstacles = MoveBackward(); break; 
                   case 'L': RotateLeft(); break; 
                   case 'R': RotateRight(); break; 
                }
                if (obstacles == 1)
                    break;
            }
            return obstacles;
        }

        private int CheckObstacles()
        {
            var randomGenerator = new Random();
            
            var rnd= randomGenerator.Next(1,10);

            _logger.LogDebug("random obstacles {}",rnd.ToString());

            return rnd;

        }

        private void Wrap()
        {
            if (_x > _xMax) _x = 0; 
            else
            if (_y > _yMax) _y = 0;
            else 
            if (_x < 0) _x = _xMax;    
            else 
            if (_y < 0) _y = _yMax;
        }

        private int MoveForward()
        {
            int obstacles = CheckObstacles();
            if (obstacles != 1)
            {
                switch (_direction)
                {
                    case 'N': _y += 1; break;
                    case 'S': _y -= 1; break;
                    case 'E': _x += 1; break;
                    case 'O': _x -= 1; break;
                }
                Wrap();
                return 0;
            }

            return obstacles;
        }
        
        private int MoveBackward()
        {
            int obstacles = CheckObstacles();
            if (obstacles != 1)
            {
                switch (_direction)
                {
                    case 'N': _y -= 1; break;
                    case 'S': _y += 1; break;
                    case 'E': _x -= 1; break;
                    case 'O': _x += 1; break;
                }
                Wrap();
                return 0;
            }
            return obstacles;
        }
        
        
        private void RotateRight()
        {
            switch (_direction)
            {
                case 'N': _direction='E'; break;
                case 'E': _direction='S'; break;
                case 'S': _direction='O'; break;
                case 'O': _direction='N'; break;
            }
        }
        
        private void RotateLeft()
        {
            switch (_direction)
            {
                case 'N': _direction='O'; break;
                case 'O': _direction='S'; break;
                case 'S': _direction='E'; break;
                case 'E': _direction='N'; break;
            }
        }
    }
}