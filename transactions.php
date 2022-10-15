<?php
$servername = "localhost";
$username = "yeraytm";
$password = "TeKhudcX6W";
$db = "yeraytm";

$conn = mysqli_connect($servername, $username, $password, $db);

if(!$conn) {
    die("ERROR: Connection failed: " . mysqli_connect_error());
}

$userID = $_REQUEST["userID"];
$itemID = $_REQUEST["itemID"];
$transactionDate = $_REQUEST["transactionDate"];

$sql = "INSERT INTO Transactions (UserID, DateTransaction) VALUES ('$userID', '$transactionDate')";

if ($conn->query($sql) === TRUE) {
    echo "New transaction record created successfully";
  } else {
    echo "Error: " . $sql . "<br>" . $conn->error;
  }
?>