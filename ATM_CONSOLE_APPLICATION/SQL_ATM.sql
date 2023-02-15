CREATE DATABASE IF NOT EXISTS ATM CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci;

USE ATM;

CREATE TABLE IF NOT EXISTS User(
  id_user int AUTO_INCREMENT PRIMARY KEY,
  full_name varchar(255) NOT NULL,
  Date_Of_Birth date NOT NULL,
  Address varchar(255) NOT NULL,
  username varchar(255) NOT NULL UNIQUE,
  password varchar(255) NOT NULL,
  email varchar(255) NOT NULL UNIQUE,
  number_phone varchar(11) NOT NULL UNIQUE,
  created_at timestamp DEFAULT CURRENT_TIMESTAMP(),
  role enum("admin","customer") DEFAULT "customer",
  status enum("normal","remove"))
  CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci;

CREATE TABLE IF NOT EXISTS Bank_Account(
  id_bank_account int AUTO_INCREMENT PRIMARY KEY,
  id_user int,
  number_bank varchar(10) NOT NULL UNIQUE,
  balance double DEFAULT 0,
  created_at_bank_account timestamp DEFAULT CURRENT_TIMESTAMP(),
  status enum("normal","remove"),
  FOREIGN KEY (id_user) REFERENCES User(id_user))
  CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci;

CREATE TABLE IF NOT EXISTS Card(
  id_card int AUTO_INCREMENT PRIMARY KEY,
  id_bank_account int,
  number_card varchar(16) NOT NULL,
  card_type enum("napas","visa","mastercard"),
  cvv varchar(3) DEFAULT NULL,
  expiration_date date,
  status enum("normal","remove"),
  created_at_card timestamp DEFAULT CURRENT_TIMESTAMP(),
  FOREIGN KEY(id_bank_account) REFERENCES Bank_Account(id_bank_account))
  CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci;

CREATE TABLE IF NOT EXISTS Transaction(
  id_transaction int AUTO_INCREMENT PRIMARY KEY,
  id_bank_account int,
  type enum("withdraw","recharge","tranfer","deposit", "withdraw_in_deposit") NOT NULL,
  amount double,
  description varchar(255),
  created_at_transaction timestamp DEFAULT CURRENT_TIMESTAMP(),
  status enum("normal","remove"),
  FOREIGN KEY (id_bank_account) REFERENCES Bank_Account(id_bank_account))
  CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci;

CREATE TABLE IF NOT EXISTS Deposit(
  id_deposit int AUTO_INCREMENT PRIMARY KEY,
  id_bank_account int,
  amount_deposit double,
  amount_interest double DEFAULT 0,
  interest_rate double NOT NULL,
  created_at_deposit timestamp DEFAULT CURRENT_TIMESTAMP(),
  maturity_date date NOT NULL, 
  status enum("complete","incomplete"),
  FOREIGN KEY (id_bank_account) REFERENCES Bank_Account(id_bank_account))
  CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci;

CREATE TABLE IF NOT EXISTS mail_code(
  id_mail_code int AUTO_INCREMENT PRIMARY KEY,
  code varchar(4),
  type enum("register","withdraw","deposit","transaction","withdraw_in_deposit"),
  id_transaction int,
  created_at_mail_code timestamp DEFAULT CURRENT_TIMESTAMP(),
  FOREIGN KEY(id_transaction) REFERENCES Transaction(id_transaction))
  CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci;
