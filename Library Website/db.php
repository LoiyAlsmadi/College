<?php
	$con=mysqli_connect("localhost","root","","book");
	//check connection
	if (mysqli_connect_errno())
	{
	echo "Failed to connect to MySQL: " . mysqli_connect_error();
	}
?>