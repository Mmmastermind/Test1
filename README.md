
<h1>Документация библиотеки RecipeManager</h1>
<p>Библиотека RecipeManager предоставляет функциональные возможности для управления списком рецептов. Она позволяет добавлять, удалять, обновлять и искать рецепты на основе различных критериев.</p>
<h2>1.	Основные классы</h2>
<p>Recipe: Представляет отдельный рецепт с такими свойствами, как Id, Name, Ingredients, Type, Difficulty и PreparationTime.</p>
<p>RecipeManager: Управляет коллекцией объектов Recipe. Он предоставляет методы для добавления, удаления, обновления и поиска рецептов.</p>
<h2>2.	Основные функции</h2>
<p>AddRecipe(Recipe recipe): Добавляет новый рецепт в менеджер. Выбрасывает ArgumentNullException, если рецепт имеет значение null.</p>
<p>DeleteRecipe(int id): Удаляет рецепт по его идентификатору. Выбрасывает Exception, если идентификатор недействителен. Выбрасывает KeyNotFoundException, если рецепт не найден.</p>
<p>UpdateRecipe(Recipe recipe): Обновляет существующий рецепт. Выбрасывает ArgumentNullException, если рецепт имеет значение null. Выбрасывает KeyNotFoundException, если рецепт не найден.</p>
<p>GetRecipeById(int id): Возвращает рецепт по его идентификатору. Выбрасывает Exception, если идентификатор недействителен. Выбрасывает KeyNotFoundException, если рецепт не найден.</p>
<p>GetAllRecipes(): Возвращает список всех рецептов.
Возвращает рецепты, содержащие какие-либо из указанных ингредиентов. Выбрасывает Exception, если список ингредиентов имеет значение null или пуст.</p>
<p>GetRecipeCount(): Возвращает общее количество рецептов.</p>
<p>GetRecipesByType(string type): Возвращает рецепты указанного типа. Выбрасывает Exception, если тип имеет значение null или пуст.</p>
<p>GetRecipesByDifficulty(string difficulty): Возвращает рецепты указанной сложности. Выбрасывает Exception, если сложность имеет значение null или пуста.</p>
<p>GetRecipesByPreparationTime(int maxTime): Возвращает рецепты, время приготовления которых не превышает указанное maxTime. Выбрасывает Exception, если maxTime недействителен.</p>
<h2>3.	Обработка исключений</h2>
Библиотека использует исключения для указания ошибок или недействительных условий. К общим исключениям относятся:
ArgumentNullException: Выбрасывается, когда метод получает аргумент со значением null, который не разрешен.
<h2>4.	Применение:</h2>
<h4>1.	Личный органайзер рецептов: </h4>
<ul>
  <li>  Создавать и сохранять рецепты, включая их названия, ингредиенты, инструкции, время приготовления, сложность и тип.</li>
  <li>Организовывать рецепты по типам (например, завтрак, обед, ужин, десерт) или по сложности (простой, средний, сложный).
</li>
  <li>Быстро находить рецепты по ингредиентам, если вы хотите приготовить что-то, используя то, что у вас уже есть.
</li>
  <li>Легко просматривать все свои рецепты или искать конкретные рецепты по названию или идентификатору.
</li>
</ul>

<h4>2.	Приложение для планирования еды. </h4>
<ul>
  <li>  Управление большой базой данных рецептов, предлагаемых пользователям.</li>
    <li>Предоставление пользователям возможности фильтровать рецепты по различным критериям, таким как время приготовления или сложность, чтобы найти то, что соответствует их графику и навыкам.</li>
    <li>Включение функции поиска рецептов по ингредиентам, чтобы пользователи могли находить рецепты на основе ингредиентов, доступных в их кладовой или недавно приобретенных.</li>




</ul>
