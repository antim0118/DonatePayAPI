# DonatePayAPI
Реализация API для DonatePay на C#

Скачать: https://github.com/antimYT/DonatePayAPI/releases

Документация: http://donatepay.ru/page/api

# Как использовать/Usage

`DonatePay.API api = new DonatePay.API(/* ваш api key */);` - создать экземпляр класса

`var user = api.User;` - получить информацию о пользователе

`var transactions = api.Transactions(/* можно ввести параметры или по-умолчанию */);` - получить информацию о донатах

`var notification = api.Notification(/* параметры */);` - создать "фейковый" донат

Также в репозитории есть папка Example, где вы можете ознакомиться с примером работы API.

P.S: Любые функции работают согласно API, как по ссылке выше.

# Предупреждение
Любую операцию при помощи API можно использовать раз в 20 секунд, согласно правилам DonatePay.
