class Player_One extends GameEntity
{
   Player_One()
   {
     position.x = 70;
     position.y = 220;
   }
   
   void update()
   {
     //check if any of the keys are pressed move inside own half (box)
      if (Football_Pong.checkKey('W') || Football_Pong.checkKey('w'))
      { 
        if(position.y > 100)
        {
          position.y = position.y - 2;
        }
      }
      if (Football_Pong.checkKey('S') || Football_Pong.checkKey('s'))
      {
        if(position.y < 340)
        {
          position.y = position.y + 2;
        }
      }
      if (Football_Pong.checkKey('A') || Football_Pong.checkKey('a'))
      {
        if(position.x > 52)
        {
          position.x = position.x - 2;
        }
      }    
      if (Football_Pong.checkKey('D') || Football_Pong.checkKey('d'))
      {
        if(position.x < 380)
        {
          position.x = position.x + 2;
        }
      }
   }
   void display() 
   {
      pushMatrix();
      noStroke();
      fill(255,0,0);
      rect(position.x, position.y, 10, 60);
      popMatrix();
   } 
}
