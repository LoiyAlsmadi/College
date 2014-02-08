//import minim (audio library)
import ddf.minim.*;

AudioPlayer player;//player that plays WAV, AIFF, AU, SND, and MP3 files
Minim minim;//audio context

Ball b_ball;
Player_One player1;
Player_Two player2;

int score1;
int score2;
PFont font;
boolean finished;
void setup()
{
  // resize the display to make it larger
  size(800, 500);
  frameRate(100);
  smooth();
  font = createFont("Calibri",16,true); 
  
  
  b_ball = new Ball();
  player1 = new Player_One();
  player2 = new Player_Two();
  score1 = 0;
  score2 = 0;
  minim = new Minim(this);
  
  //make boolean finished false
  finished = false;
}
  
void draw()
{
  //only draw if the game is not finished
  if (finished == false)
  {
    // change the color of our background
    background(255, 255, 0);
    
    // change the line color
    stroke(255);
    // change the fill color for circle and rectangles
    fill(0, 255, 0);
    
    // chang the line width
    strokeWeight(8);
    // draw Pitch (rectangle)
    rect(50, 100, 700, 300);
    
    //Draw corners
    arc(750, 101, 25, 25, HALF_PI, PI);
    arc(750, 399, 25, 25, -PI, -HALF_PI);
    arc(51, 101, 25, 25, HALF_PI-HALF_PI, HALF_PI);
    arc(51, 399, 25, 25, -HALF_PI,  HALF_PI-HALF_PI);
    
    // chang the line width
    strokeWeight(1);
    // Draw Boxes
    rect(50, 190, 75, 125);
    rect(675, 190, 75, 125);
    
    // draw the center half
    ellipse(400, 250, 150, 150);
  
    // draw the center line
    line(400, 100, 400, 400);
    
    // change the fill color for center half
    fill(255);
    // draw the kickoff spot
    ellipse(400, 250, 10, 10);
    
    // change the fill color for the scores
    fill(0);
    //Display Scores
    textSize(25);
    text("PLAYER ONE", 50, 50);
    text("PLAYER TWO", width-200, 50);
    textSize(40);
    text(score1, 50, 90);
    text(score2, width-80, 90);
    
    //if player_one scors
    if (b_ball.add1 == true)
    {
      b_ball.velocity =  PVector.random2D();
      //change the speed_limit back to 15
      b_ball.speed_limit = 15;
      //add 1 to score
      score1 = score1 + 1;
      //call Score() method
      Score();
      b_ball.add1 = false;
      //if player_one reaches 7
      if (score1 == 7)
      {
        fill(250,0,0);
        //send message to Winner() method
        Winner("PLAYER ONE WINS");
      }
    }
    //if player_two scores (involves same steps as player_one)
    if (b_ball.add2 == true)
    {
      b_ball.velocity =  PVector.random2D();
      b_ball.speed_limit = 15;
      score2 = score2 + 1;
      Score();
      b_ball.add2 = false;
      if (score2 == 7)
      {
        fill(250,0,250);
        Winner("PLAYER TWO WINS");
      }
    }
    
    //Call methods in different classes
    b_ball.update();
    b_ball.display();  
    b_ball.checkBoundaryCollision();
    b_ball.checkPlayerCollision();
    player1.update();
    player1.display();
    player2.update();
    player2.display();
  }
}

void Score()
{
  //Play sound clip "goal.mp3"
  player = minim.loadFile("goal.mp3", 2048);
  player.play();
  //change the positions of the player bars back to intial place
  player1.position.x = 70;
  player1.position.y = 220;
  player2.position.x = 725;
  player2.position.y = 220;
  //call delay() method
  delay(3500);
}

void Winner(String text)
{
  //play sound clip "crowd.mp3"
  player = minim.loadFile("crowd.mp3", 2048);
  player.play();
  //make finished true
  finished = true;
  //change scores back to 0
  score1 = 0;
  score2 = 0;
  
  textSize(40);
  //display winner text
  text(text, 200, 200);
  text("Click To Start a New Game", 150, 300);
  //if click mousePressed() is called
}

void Ping()
{
  //play sound clip "ping.mp3"
  player = minim.loadFile("ping.mp3", 2048);
  player.play();
}

void mousePressed()
{
  finished = false;
  player.close(); 
}

void stop() 
{ 
  //stop or close all the sound players
  player.close(); 
  minim.stop(); 
  super.stop(); 
} 

void delay(int delay)
{
  //store the current time
  int time = millis();
  //while the difference between now and time is < or = to delay
  while(millis() - time <= delay);
}

static boolean[] keys = new boolean[526];

static boolean checkKey(int k)
{
  if (keys.length >= k) 
  {
    return keys[k];  
  }
  return false;
}

void keyPressed()
{ 
  keys[keyCode] = true;
}
 
void keyReleased()
{
  keys[keyCode] = false; 
}

