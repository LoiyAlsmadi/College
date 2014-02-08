<!DOCTYPE html>
<html>
	<head>
		<style>
			img
			{ 
				border-radius: 20px / 20px ;
				position:absolute;
				left:200px;
			}
			div#logout
			{ 
				position:absolute;
				right:20px;
				margin-top:30px;
			}
			div
			{
				border-radius: 15px / 15px ;
			}
			div#shadow
			{
				box-shadow:0px 0px 15px 2px #151515;
			}
			table, th, td
			{
				border:1px solid #2ECCFA;
				border-radius: 5px / 5px;
			}
		</style>
		<link type='text/css' rel='stylesheet' href='style.css'>
	</head>
	<body>
		<div style="position:relative;">
			<div id="shadow" style="position:absolute; left:12%; width:1000px; height:160px; background-color:white; border:1px; visibility:visible">
				
				<br><a href="Homepage.html"><img src="libraryLOGO.jpg" name="logo" width="500" height="100" /></a>
				
				<div id="logout" class="links">
					<?php
						session_start();
						// Check, if username session is set
						if (isset($_SESSION['username'])) 
						{
							echo "Hello, " . $_SESSION['username'];
							echo"<button> <a style='text-decoration:none' href='logout.php'>Logout</a></button>";
						}
					?>
				</div>
				
				<div class="links" style="position:absolute; left:15%; top:80%; width:700px; height: 20px; background-color:#2ECCFA; border:1px; visibility:visible">			
					<a style="text-decoration:none" href="Homepage.html">HOME</a>
					<a style="text-decoration:none; margin-left:25px" href="Login.php">LOGIN</a>
					<a style="text-decoration:none; margin-left:25px" href="Registration.html">REGISTRATION</a>
					<a style="text-decoration:none; margin-left:25px" href="Search.php">SEARCH</a>
					<a style="text-decoration:none; margin-left:25px" href="Account.php">ACCOUNT</a>
				</div>
				
			</div>
			
			<div id="shadow" style="position:absolute; left:22%; margin-top:225px; width:700px; height:550px; background-color:white; border:1px; visibility:visible">
				<br>
				<div class="header" style="position:center; width:700px; height: 25px; background-color:#2ECCFA; border: 1px; visibility:visible">
					<h3>Books Reserved</h3>
				</div>
				<br>
				<?php
					require_once "db.php";
					// Check, if username session is NOT set then this page will jump to login page
					if (!isset($_SESSION['username'])) 
					{
						header('Location: login.php');
					}
					else
					{
						$query = "SELECT *,reservedDate FROM books INNER JOIN reservations WHERE books.isbn = reservations.isbn AND reservations.username='$_SESSION[username]'";
						$res = mysqli_query($con,$query);
						echo '<table border="1" align="center">'."\n";
						echo "<tr><td>"; 
						echo 'ISBN'; 
						echo("</td><td>"); 
						echo 'Title'; 
						echo("</td><td>\n"); 
						echo 'Author'; 
						echo("</td><td>\n"); 
						echo 'Edition';
						echo("</td><td>\n"); 
						echo 'Year'; 
						echo("</td><td>\n");
						echo 'Category ID'; 
						echo("</td><td>\n");
						echo 'Reserved Date'; 
						echo("</td></tr>");					
						while ( $row = mysqli_fetch_row($res) ) 
						{ 
							echo "<tr><td>"; 
							echo(htmlentities($row[0])); 
							echo("</td><td>"); 
							echo(htmlentities($row[1])); 
							echo("</td><td>\n"); 
							echo(htmlentities($row[2])); 
							echo("</td><td>\n"); 
							echo(htmlentities($row[3]));
							echo("</td><td>\n"); 
							echo(htmlentities($row[4])); 
							echo("</td><td>\n");
							echo(htmlentities($row[5]));
							echo("</td><td>\n");
							echo(htmlentities($row[9]));
							echo("</td></tr>"); 
						}
						echo '</table>';
					}
					if (!mysqli_query($con,$query))
					{
						die('Error: ' . mysqli_error($con));
					}
				?>
			</div>
		</div>
	</body>
</html>
