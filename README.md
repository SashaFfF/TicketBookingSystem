# TicketBookingSystem
Филипеня Александра, гр. 153503  
Система покупки и бронирования билетов на мероприятия (концерты, кино, театр и т.д.).  
## Диаграмма классов
![Diagram](https://github.com/SashaFfF/TicketBookingSystem/blob/main/new_diagram.jpg)
## Функционал:
1. Стартовая страница  
a)	Возможность выбора вкладки с типом мероприятия, Категория “Кино” по умолчанию  
b)	Внутри каждой вкладки возможность фильтра мероприятий по дате  
c)	Внутри каждой вкладки возможность фильтра мероприятий по городу  
d)	Внутри каждой вкладки возможность фильтра мероприятий по месту проведения  
e)	Возможность открытия страницы мероприятия  
2. Страница мероприятия  
a)	Отображение информации о:  
i.	Название мероприятия  
ii.	Описание мероприятия  
iii.	Город  
iv.	Место проведения  
v.	Дата  
vi.	Огранизатор  
vii.	Возрастное ограничение  
viii.	Информация о наличии доступных билетов (Sold Out если билетов нет)  
b)	Возможность забронировать билет (кнопка “Забронировать”)  
3. Страница бронирования билетов  
a)	Информация о доступных билетах:  
i.	Цена  
ii.	Диапазон мест  
iii.	Количество  
b)	Возмождность забронировать - (кнопка “Забронировать” для каждого типа доступных билетов)  
4. Страница контактной информации клиента:  
a)	Номер телефона  
b)	Адрес электронной почты  
5. Страница оплаты:  
a)	Ввод данных банковской карты  
b)	Оплата  
6. Страница информация о приобретенном билете:  
a)	Название мероприятия  
b)	Дата  
c)	Город  
d)	Место проведения  
e)	Ряд, место  
7. Генерация билета в формате pdf  
8. Отправка билета по электронной почте с использованием MailKit  
## Описание моделей данных
Event:  
- Id;  
- Name: string;  
- EventType: EventType (поле для хранения информации о типе мероприятия: кино, концерты, выставки и т.д.);  
- Description: string;  
- EventLocation: Location (поле для хранения информации о месте проведения мероприятия);  
- Date: DateTime;  
- EventOrganizer: Organizer (поле для хранения информации об организаторе мероприятия);  
- EventAgeLimit: AgeLimit. 
 
EventType:  
- Id;  
- Type: string.  

Location:  
- Id;  
- City: string;  
- Street: string;  
- BuildingNumber: int;  
- BuildingName: string.  

Organizer (организатор мероприятия):  
- Id;  
- Name: string;  
- OrganizerLocation: Location;  
- PhoneNumber: string.  

AgeLimit:  
- Id;  
- Value: int.  

Ticket:  
- Id;  
- Event: Event;  
- TicketStatus: Status (поле для хранения информации о состоянии билета, возможные значения: доступен для продажи, забронирован, оплачен);  
- TicketCategory: Category(описание категории билета, цена);  
- Row: int;  
- Number: int.  

Status:  
- Id;  
- Value: string (возможные значения билета: свободен для продажи, забронирован, оплачен).  
  
Category:  
- Id;  
- Price: double;  
- Description: string.  

Client:  
- Id;  
- PhoneNumber: string;  
- Email: string.  

Purchase:  
- Id;  
- Client: Client;  
- Ticket: Ticket.  

## Ticket Booking Library 
### ControllerLibrary  
### - TicketController 
 **tickets: List<Ticket\>**   
   
 **categories: List<Category\>**  
   
 **Dictionary<string, int> GetCountOfFreeTickets(Event ev)**  
 Метод для нахождения количества доступных билетов определенной категории. Возвращает словарь, где ключ - категория билета, значение - количество свободных билетов этой категории.  
   
 **int GetFirstFreeTicket(Event ev, Category ticketCategory)**  
 Метод для выбора билета для бронирования. Возвращает Id первого доступного для бронирования билета определенной категории.
   
 **int BookTicket(int ticketId)**  
 Метод для бронирования билета. Изменяет статус билета с "доступен" на "забронирован" и возвращает Id забронированного билета.
   
 **int BuyTicket(int ticketId)**  
 Метод для покупки билета. Изменяет статус билета с "забронирован" на "приобретен" и возвращает Id приобретенного билета.
 
### - TicketGenerationController  
 **BackgroundImage: string**   
 Является фоновым изображением всех билетов.  
   
 **string GenerationTicketPdf(Ticket ticket)**  
 Метод, генерирующий билет в формате pdf и возвращающий путь, по котрому был сохренен данный билет. Для созданания pdf-документа используется itext7.2.5. Метод принимает один параметр: билет, свойства которого будут подставляться в общий шаблон билетa.       
   
***Шаблон билета***  
  
 <img src="https://github.com/SashaFfF/TicketBookingSystem/blob/Lab2/ticket%20template.jpg" width="400" height="590">  
   
 Метод будет вызываться при нажатии на кнопку "Получить билет".  
    
 **void SendEmail(string recipient, string ticketPath)**  
 Метод для отправки билета на Email. Для реализации данного метода использован MailKit версии 3.6.0. Метод принимает два параметра: электроонную почту получателя (string recipient) и путь (string ticketPath), по которому был сохранен сгенерированный билет. Электронная почта получателя будет вводиться пользователем в текстовое поле Entry.  
