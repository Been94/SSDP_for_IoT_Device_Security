<?php
$conn = mysqli_connect(
  'localhost', // 주소
  'root',
  'root',
  'SSDPS');
   $user_id = $_POST['uid'];
   $uuid_val = $_POST['user_uuid'];
 
 	$sql = "SELECT * FROM users WHERE id ='{$user_id}'";
	$result = mysqli_query($conn, $sql);
	$count = mysqli_num_rows($result);
 
 if($user_id != '' || $count != 0){

	 $sql = "DELETE FROM device WHERE uuid = '{$uuid_val}'";
	
	$result = mysqli_query($conn, $sql);
	 
	 if ($result === false) {
		 echo '0';
	 }else{
		 echo '1';
	 } 
 }else{
 echo '0';
 }
?>