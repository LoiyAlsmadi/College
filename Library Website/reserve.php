<?php
session_start();
// Check, if username session is NOT set then this page will jump to login page
if (!isset($_SESSION['username'])) 
{
	header('Location: login.php');
}
else
{
	if (isset($_POST['submitButton'])) 
	{
		require_once "db.php";
		
		$isbn = mysql_real_escape_string($_POST['isbn']);

		if($isbn != "")
		{
			$query = "SELECT * FROM books WHERE isbn LIKE '%".$isbn."%'";
			$res = mysqli_query($con,$query);
			
			$row = mysqli_fetch_row($res);
			if(htmlentities($row[6]) != 'Y')
			{
				// Return date info;
				$date = date("y/m/d");
				$sqlUpdate = "UPDATE books SET reserved='Y' WHERE isbn='$isbn'";
				if (!mysqli_query($con,$sqlUpdate))
				{
					die('Error: ' . mysqli_error($con));
				}
					
				$sql = "INSERT INTO reservations (isbn, username, reservedDate) VALUES('$isbn','$_SESSION[username]','$date')";
				if (!mysqli_query($con,$sql))
				{
					die('Error: ' . mysqli_error($con));
				}
				header( 'Location: Account.php' ) ;
			}
			else
			{
				echo "Book already reserved";
			}
		}
	}
}
?>
