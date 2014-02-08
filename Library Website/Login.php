<!DOCTYPE html>
<html>
	<head>
		<style>
			img#logo
			{ 
				border-radius: 20px / 20px ;
				position:absolute;
				left:200px;
			}
			div
			{
				border-radius: 15px / 15px ;
			}
			div#shadow
			{
				box-shadow:0px 0px 15px 2px #151515;
			}
		</style>
		<link type='text/css' rel='stylesheet' href='style.css'>
	</head>
	<body>
		<div style="position:relative;">
			<div id="shadow" style="position:absolute; left:12%; width:1000px; height:160px; background-color:white; border:1px; visibility:visible">
				
				<br><a href="Homepage.html"><img id="logo" src="libraryLOGO.jpg" name="logo" width="500" height="100" /></a>
				
				<div class="links" style="position:absolute; left:15%; top:80%; width:700px; height: 20px; background-color:#2ECCFA; border:1px; visibility:visible">			
					<a style="text-decoration:none" href="Homepage.html">HOME</a>
					<a style="text-decoration:none; margin-left:25px" href="Login.php">LOGIN</a>
					<a style="text-decoration:none; margin-left:25px" href="Registration.html">REGISTRATION</a>
					<a style="text-decoration:none; margin-left:25px" href="Search.php">SEARCH</a>
					<a style="text-decoration:none; margin-left:25px" href="Account.php">ACCOUNT</a>	
				</div>
				
			</div>
			
			<div id="shadow" style="position:absolute; left:22%; margin-top:225px; width:700px; height:550px; background-color:white; border:1px; visibility:visible">
				<form name="reg" method="post" class="writing">
					<br>
					<div class="header" style="position:center; width:700px; height: 25px; background-color:#2ECCFA; border: 1px; visibility:visible">
						<h3>LOGIN</h3>
					</div>
					<br>
					Username:<input type="text" name="username" size="15" maxlength="30" /><br>
					Password:<input type="password" name="password" size="10" maxlength="6" /><br>
					<input type="submit"  name="submitButton" value="Login" /> 
				</form>
				
				<?php
				if (isset($_POST['submitButton'])) 
				{
					require_once "db.php";
					// Initialise session
					session_start();
					
					$username= mysql_real_escape_string($_POST['username']); 
					$password= mysql_real_escape_string($_POST['password']); 
					
					$sql="SELECT * FROM users WHERE username='$username' and password='$password'";
					$result=mysqli_query($con,$sql);

					// Mysql_num_row is counting table row
					$count=mysqli_num_rows($result);
					// If result matched $myusername and $mypassword, table row must be 1 row
					if($count==1)
					{
						// Register $myusername, $mypassword and redirect to file "login_success.php"
						$_SESSION['username'] = $username; 
						header( 'Location: Account.php' ) ;
					}
					else 
					{
						echo "Wrong Username or Password";
					}
					
					if (!mysqli_query($con,$sql))
					{
						die('Error: ' . mysqli_error($con));
					}
				}
				?>
			</div>
		</div>
	</body>
</html>
