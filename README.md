# NoSql

Social Media app using wpf and Neo4j

Коротенько про функціонал.
Коли Ви заходите в профіль людини вам висвітлюється Connection (Найблищій! шлях) а також можете переглянути Ваших спільних друзів.
Є ще вікно де ви можете просто переглянути всіх друзів ваших друзів.
При додаванні дового користувача , користувач додається і в mongodb i в neo4j.
Також коли ви починаєте фоловити людини або ж анфолити дія відбувається і в mongo і в neo4j

Прикріплю невеличку пдфку де продемострую роботу програми




Social Media app using wpf and mongodb

короткий поверхневий опис програми

1) Користувач може зареєстурватися , якщо він зареєстрований то він логіниться.
Паролі хешуються.
При стовренні нового користувача перевіряється чи користувач водить унікальний нікнейм.

2) Коли користувач залогінився перед ним відкривається вікно ucNews.
В цьому вікні відображаються всі нові пости його ДРУЗІВ (в мому випадку людей яких я фоловлю). 
Тобто в мене є окремо певний список людей за якими я стежу Following і список людей які стежать за мною Followers.
У вікні ucNews відображаються пости людей за якими я стежу, але лише нові пости.
Що таке нові пости?
В базі даних для кожного користувача я зберігаю час його останнього використання програми,
тобто коли користувач закриває програму дата оновлюється .
Отже коли користувач відкриває вікно ucNews він бачить лише пости своїх друзів які були створені після того як він переглядав стрічку новин
Користувач має змогу : 

  a) лайкнути пост
  
  b) дислайкнути пост
  
  c) прокоментувати пост
  
  d) переглянути список людей які прокоментували пост і відповідно їх коментарі 
  
  e) переглянути список людей які лайкнули і дислайкнули пост
  
  f) має змогу переглянути кількість лайків і дислайків 
  
  g) може легко перейти на сторінку людини яка написала цей пост
  
3) вікно ucMyProfile відобрається профіль користувача 
там він може :

  a)переглянути всі свої пости
  
  b)редагувати і додавати нові пости
  
  c)видаляти пости
  
  d)переглядати список людей які за ним стежать і за якими стежить він
  
  e)переглядати хто коментував лайкав і дислайкав його пости  
  
4) вікно ucProfileEdit користувач мого редагувати свої дані 

5) вікно ucChangePassword для зміни паролю

6) вікно ucFind для пошуки людини 
якшо людину знайдено то користовачу відкриє вікно з профілем тої людини
там користувач може :

  a) переглянути пости людини
  
  b) лайкнути їх , якщо ж він зробив це вже раніше то кнопка буде підсвічуватися зеленим
  
  c) дислайкнути їх , якщо ж він зробив це вже раніше то кнопка буде підсвічуватися червоним
  
  d) переглянути за ким стежить людина і хто стежить за людиною
  
  e) почати стежити за людиною або відписатися від людини
  
  f) переглянути хто коментує , лайкає і дислайкає людину
  
Всі помилки опрацьовуються і виводяться користовачеві в спеціальному MessageWindow

Отже в програмі втілені всі поставленні вимоги а також втіленна опція ДРУЗІВ 

Недоліки програми 

Services я не встиг втілити найкращим чином.
це я оцінюю як найбільший недолік програми . Також було б круто якби коли користувач додає нові  пости не потрібно було рефрешати сторінку а воно б оновлювалась 
самостійно . А так то інстаграм ховається )) 


