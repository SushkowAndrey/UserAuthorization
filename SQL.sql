добавление логина и пароля
INSERT INTO host1323541_itstep37.table_account (login, password) VALUES ('123', '123')
добавление пользователя
INSERT INTO host1323541_itstep37.table_users (name, column_6, email, phone, date_birth, account_id) VALUES ('имя', null, 'test@test.ru', '123123123', '2021-03-16', 1)
количество строк пользователя
SELECT COUNT(*) FROM table_users