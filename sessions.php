<?php
$servername = "localhost";
$username = "yeraytm";
$password = "TeKhudcX6W";
$db = "yeraytm";

$conn = mysqli_connect($servername, $username, $password, $db);

if(!$conn) {
    die("ERROR: Connection failed: " . mysqli_connect_error());
}

$isNewSession = $_REQUEST["isNewSession"];

if($isNewSession) {
  $userID = $_REQUEST["userID"];
  $sessionStart = $_REQUEST["sessionStart"];
  $sql = "INSERT INTO UsersInfo (UserID, TimeLogin) VALUES ('$userID','$sessionStart')";
}
else {
  $sessionID = $_REQUEST["sessionID"];
  $sessionEnd = $_REQUEST["sessionEnd"];
  $sql = "UPDATE Sessions SET TimeLogout = $sessionEnd WHERE SessionID = $sessionID";
}

if ($conn->query($sql) === TRUE) {
  $sessionIDRet = $conn->insert_id;
  echo $sessionIDRet;
}
?>