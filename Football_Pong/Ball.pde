class Ball extends GameEntity
{
  boolean add1 = false;
  boolean add2 = false;
  float speed;
  int speed_limit = 15;
  
  Ball()
  {
    velocity = PVector.random2D();
    position.x = 400;
    position.y = 250;
    speed = 1.1f;
  }
  
  void update()
  {
    position.add(velocity);
  }
  
  void checkBoundaryCollision() 
  {
    //check collision with far right
    if (position.x > 750)
    {
      //if the ball is in the goal
      if (position.y > 191 && position.y < 315)
      {
        add1 = true;
        position.x = 400;
        position.y = 250;
        velocity.x *= -1;
      }
      else //make the ball bounce back
      {
        position.x = 750;
        velocity.x *= -1;
        Ping(); 
      }
    }
    else if (position.x < 50) //check collision with far left
    {
      //if the ball is in the goal
      if (position.y > 190 && position.y < 315)
      {
        add2 = true;
        position.x = 400;
        position.y = 250;
        velocity.x *= -1;
      }
      else //make the ball bounce back
      {
        position.x = 50;
        velocity.x *= -1;
        Ping(); 
      }
    }
    else if (position.y > 400) //check collision with bottom of pitch
    {
      position.y = 400;
      velocity.y *= -1;
      Ping(); 
    } 
    else if (position.y < 100) //check collision with top of pitch
    {
      position.y = 100;
      velocity.y *= -1;
      Ping(); 
    }
  }
  
  void checkPlayerCollision()
  {
    //Check collision with the top of the player bars
     if(dist(b_ball.position.x, b_ball.position.y, player1.position.x+10, player1.position.y) < 15)
     {
       Ping();
       velocity.x *= -1;
       if(speed_limit > 0)
       {
         velocity.mult(speed);
         speed_limit -= 1;
       }
     } 
     if(dist(b_ball.position.x, b_ball.position.y, player2.position.x, player2.position.y) < 15)
     {
       Ping();
       velocity.x *= -1;
       if(speed_limit > 0)
       {
         velocity.mult(speed);
         speed_limit -= 1;
       }
     } 
     
     //Check collision with the bottom of the player bars
     if(dist(b_ball.position.x, b_ball.position.y, player1.position.x+10, player1.position.y+60) < 15)
     {
       Ping();
       velocity.x *= -1;
       if(speed_limit > 0)
       {
         velocity.mult(speed);
         speed_limit -= 1;
       }
     }
     if(dist(b_ball.position.x, b_ball.position.y, player2.position.x, player2.position.y+60) < 15)
     {
       Ping();
       velocity.x *= -1;
       if(speed_limit > 0)
       {
         velocity.mult(speed);
         speed_limit -= 1;
       }
     }
     
     //Check collision with the middle of the player bars
     if(dist(b_ball.position.x, b_ball.position.y, player1.position.x+10, player1.position.y+30) < 15)
     {
       Ping();
       velocity.x *= -1;
       if(speed_limit > 0)
       {
         velocity.mult(speed);
         speed_limit -= 1;
       }
     }
     if(dist(b_ball.position.x, b_ball.position.y, player2.position.x, player2.position.y+30) < 15)
     {
       Ping();
       velocity.x *= -1;
       if(speed_limit > 0)
       {
         velocity.mult(speed);
         speed_limit -= 1;
       }
     }
  }
  
  void display() 
  {
    pushMatrix();
    fill(0);
    noStroke();
    ellipse(position.x, position.y, 15, 15);
    popMatrix();
  }
}
