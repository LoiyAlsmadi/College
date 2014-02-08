class Player_Two extends GameEntity
{
   Player_Two()
   {
     position.x = 725;
     position.y = 220;
   }
   
   void update()
   {
     //check if any of the keys are pressed move inside own half (box)
      if (Football_Pong.checkKey(UP))
      {     
        if(position.y > 100)
        {
          position.y = position.y - 2;
        }
      }
      if (Football_Pong.checkKey(DOWN))
      {
        if(position.y < 340)
        {
          position.y = position.y + 2;
        }
      }
      if (Football_Pong.checkKey(LEFT))
      {
        if(position.x > 410)
        {
          position.x = position.x - 2;
        }
      }    
      
      if (Football_Pong.checkKey(RIGHT))
      {
        if(position.x < 737)
        {
          position.x = position.x + 2;
        }
      } 
   }
   void display() 
   {
      pushMatrix();
      noStroke();
      fill(250,0,250);
      rect(position.x, position.y, 10, 60);
      popMatrix();
   } 
}
