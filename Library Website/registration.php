<?php
require_once "db.php";
if (isset($_POST['submitButton'])) 
{
	$password = $_POST['password'];
	$confirm_password = $_POST['confirm_password'];

	$query = "SELECT * FROM users WHERE username='$_POST[username]'";
	$res = mysqli_query($con,$query);

	if($res && mysqli_num_rows($res)>0)
	{
		echo "Username Already Taken";
	} 
	else 
	{	
		if ($password==$confirm_password)
		{
			$sql="INSERT INTO users (username, password, firstname, surname, addressline1, addressline2, city, telephone, mobile)
			VALUES
			('$_POST[username]','$_POST[password]','$_POST[firstname]','$_POST[surname]','$_POST[address_line1]','$_POST[address_line2]','$_POST[city]','$_POST[telephone]','$_POST[mobile]')";
			$result = mysqli_query($con,$sql);
			//go to Login.php page
			header( 'Location: Login.php' ) ;
		}
		else
		{
			echo "Password Confrimation Invalid";
		}
	}

	if (!mysqli_query($con,$query))
	{
		die('Error: ' . mysqli_error($con));
	}
}	
?>


