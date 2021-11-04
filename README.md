# 2DSpriteGame_VI
Мой шестой проект по изучению Unity. Создан для практики создания 2D спрайтовых игр. Архитектура MVC.

В проекте присутсвуют:

Две сцены. Первая с UI запускающий вторую сцену, которая является основной.

В главной сцене есть игрок со спрайтовой анимацией и физическим движением через паттерн State. 

Враг с оружием, которое стреляет пулями. Враг огибает препятствия с помощью ассета A* Pathfiding Project. Оружие врага всегда повернуто в сторону игрока. 
Пули хранятся в Object Pool'e. При попадании в игрока игра оканчивается. Враг перестает отслеживать и стрелять в игрока, когда тот покидает опасную зону.

Квестовая система, суть которой в том, чтобы подобрать в нужном порядке квестовые объекты. Если нарушен порядок, то квест начинается сначала. 
После завершения квеста открывается доступ к предмету, который завершает игру.

Различные платформы и области с Joint'ами и Effector'ами.

Внутриигровой UI, на котором высвечиваются подсказки.

Возможность рандомной генерации карты методом клеточного автомата. Этот метод можно запускать через Editor. 

Фон с Parallax Effect'ом. 