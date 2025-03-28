using RecipesModul;
using System.Collections.Generic;

namespace RecipeTests;

public class Tests
{
    private readonly RecipeManager _recipeManager = new RecipeManager(); //������� ���� ��� �������� ����� ������ RecipeManager



    //���� ��� �������� ��������� ���������� �������
    [Test]
    public void AddRecipe_ValidRecipe_AddsRecipeToList()
    {

        Recipe recipe = new Recipe { Name = "Chicken Soup", Ingredients = new List<string> { "Chicken", "Vegetables" } };
        _recipeManager.AddRecipe(recipe);
        Assert.Contains(recipe, _recipeManager.GetAllRecipes()); //��������, ��� ������ ����������

    }

    //���� ��� ��������  ����������  ������� �������
    [Test]
    public void AddRecipe_NullRecipe_ThrowsArgumentNullException()
    {
        Recipe recipe1 = null;
        Assert.Throws<ArgumentNullException>(() => _recipeManager.AddRecipe(recipe1)); // ��������, ��� ������������� ����������
    }


    //���� ��� �������� ��������� �������� �������
    [Test]
    public void DeleteRecipe_ExistingRecipeId_DeletesRecipeFromList()
    {
        Recipe NewRecipe = new Recipe { Id = 1, Name = "�����", Type = "�������", Ingredients = new List<string> { "����", "������" }, Difficulty = "������", PreparationTime = 10 };
        _recipeManager.AddRecipe(NewRecipe);
        _recipeManager.DeleteRecipe(1);
        Assert.IsEmpty(_recipeManager.GetAllRecipes());//��������, ��� ���� � ��������� ����
    }

    //���� ��� ��������  �������� ��������������� �������
    [Test]
    public void DeleteRecipe_UnExistingRecipeId_DeletesRecipeFromList()
    {
        Assert.Throws<Exception>(() => _recipeManager.DeleteRecipe(999)); // ��������, ��� ������������� ����������
    }

    //���� ��� ��������  �������� �������� �������
    [Test]
    public void DeleteRecipe_InvalidId_DeletesRecipeFromList()
    {
        Assert.Throws<Exception>(() => _recipeManager.DeleteRecipe(0)); // ��������, ��� ������������� ����������
    }

    //���� ��� �������� ��������� ���������� �������
    [Test]
    public void UpdateRecipe_ExistingRecipeId_UpdateRecipe()
    {
        Recipe NewRecipe = new Recipe { Id = 1, Name = "�����", Type = "�������", Ingredients = new List<string> { "����", "������" }, Difficulty = "������", PreparationTime = 10 };
        _recipeManager.AddRecipe(NewRecipe);
        Recipe UpdateRecipe = new Recipe { Id = 1, Name = "�������", Type = "�������", Ingredients = new List<string> { "����" }, Difficulty = "������", PreparationTime = 15 };
        _recipeManager.UpdateRecipe(UpdateRecipe);
        Recipe recipe1 = _recipeManager.GetRecipeById(1);
        Assert.AreEqual("�������", recipe1.Name); // ��������, ��� � ������� ���������� ���
        Assert.AreEqual(15, recipe1.PreparationTime); //��������, ��� � ������� ���������� ����� �������������
    }

    //���� ��� ��������  ���������� ��������������� ������� �������
    [Test]
    public void UpdateRecipe_UnExistingRecipeId_ThrowException()
    {
        Recipe NewRecipe = new Recipe { Id = 1, Name = "�����", Type = "�������", Ingredients = new List<string> { "����", "������" }, Difficulty = "������", PreparationTime = 10 };
        _recipeManager.AddRecipe(NewRecipe);
        Recipe UpdateRecipe = new Recipe { Id = 999, Name = "�������" };
        Assert.Throws<Exception>(() => _recipeManager.UpdateRecipe(UpdateRecipe)); // ��������, ��� ������������� ����������
    }

    //���� ��� ��������  ���������� ������� �������
    [Test]
    public void UpdateRecipe_NullRecipeId_ThrowsNullReferenceException()
    {
        Assert.Throws<NullReferenceException>(() => _recipeManager.UpdateRecipe(null)); // ��������, ��� ������������� ����������
    }

    //���� ��� �������� ��������� ��������� �������� �� id
    [Test]
    public void GetRecipeById_ExistingRecipeId_GetRecipe()
    {
        Recipe NewRecipe = new Recipe { Id = 1, Name = "�����", Type = "�������", Ingredients = new List<string> { "����", "������" }, Difficulty = "������", PreparationTime = 10 };
        _recipeManager.AddRecipe(NewRecipe);
        Recipe recipe1 = _recipeManager.GetRecipeById(1);
        Assert.AreEqual("�����", recipe1.Name);//��������, ��� �������� ������������� �������� �������, ��� id ��� �������
    }

    //���� ��� ��������  ��������� �������������� �������� �� id
    [Test]
    public void GetRecipeById_UnExistingRecipeId_ThrowException()
    {
        Assert.Throws<Exception>(() => _recipeManager.GetRecipeById(100)); // ��������, ��� ������������� ����������
        Assert.Throws<Exception>(() => _recipeManager.GetRecipeById(-100)); // ��������, ��� ������������� ����������
        Assert.Throws<Exception>(() => _recipeManager.GetRecipeById(0)); // ��������, ��� ������������� ����������
    }


    //���� ��� �������� ��������� ��������� ���� �������� 
    [Test]
    public void GetAllReciped_AddRecipe_RecipesList()
    {
        Recipe NewRecipe = new Recipe { Id = 1, Name = "�����", Type = "�������", Ingredients = new List<string> { "����", "������" }, Difficulty = "������", PreparationTime = 10 };
        _recipeManager.AddRecipe(NewRecipe);
        List<Recipe> Recipes = _recipeManager.GetAllRecipes();
        Assert.Contains(NewRecipe, Recipes); //��������, ��� ��� ����������� ������� ������������
    }

    //���� ��� �������� ��������� ��������� ���� �������� 
    [Test]
    public void GetAllReciped_NoRecipe_EmptyRecipesList()
    {

        List<Recipe> Recipes = _recipeManager.GetAllRecipes();
        Assert.IsEmpty(Recipes);//��������, ��� ���� � ��������� ����
    }

    //���� ��� �������� ��������� ��������� �������� �� ������������
    [Test]
    public void SearchRecipesByIngredients_MatchingIngridients_ReturnReciresList()
    {

        Recipe NewRecipe = new Recipe { Id = 1, Name = "�����", Type = "�������", Ingredients = new List<string> { "����", "������" }, Difficulty = "������", PreparationTime = 10 };
        Recipe NewRecipe2 = new Recipe { Id = 2, Name = "����� ������", Type = "����", Ingredients = new List<string> { "�����", "������", "����" }, Difficulty = "�������", PreparationTime = 20 };
        _recipeManager.AddRecipe(NewRecipe);
        _recipeManager.AddRecipe(NewRecipe2);
        List<Recipe> searchResult = _recipeManager.SearchRecipesByIngredients(new List<string> { "����" });
        Assert.Contains(NewRecipe2, searchResult);//��������, ��� ������ ������ ������������ � ���������� ������
        Assert.Contains(NewRecipe, searchResult);//��������, ��� ������ ������ ������������ � ���������� ������
    }

    //���� ��� ��������  ���������  �������� �� �������������� ������������
    [Test]
    public void SearchRecipesByIngredients_NoMatchingIngridients_ReturnEmptyReciresList()
    {

        Recipe NewRecipe = new Recipe { Id = 1, Name = "�����", Type = "�������", Ingredients = new List<string> { "����", "������" }, Difficulty = "������", PreparationTime = 10 };
        _recipeManager.AddRecipe(NewRecipe);
        List<Recipe> searchResult = _recipeManager.SearchRecipesByIngredients(new List<string> { "�����" });
        Assert.IsEmpty(searchResult);//��������, ��� ���� � ��������� ����
    }

    //���� ��� ��������  ���������  �������� �� ������ ������������
    [Test]
    public void SearchRecipesByIngredients_EmptyIngridients_ThrowException()
    {

        Assert.Throws<Exception>(() => _recipeManager.SearchRecipesByIngredients(new List<string> { })); // ��������, ��� ������������� ����������
        Assert.Throws<Exception>(() => _recipeManager.SearchRecipesByIngredients(null)); // ��������, ��� ������������� ����������
    }



    //���� ��� �������� ��������� ��������� ���������� ��������
    [Test]
    public void GetRecipeCount_RecipesList_CorrectCount()
    {

        Recipe NewRecipe = new Recipe { Id = 1, Name = "�����", Type = "�������", Ingredients = new List<string> { "����", "������" }, Difficulty = "������", PreparationTime = 10 };
        _recipeManager.AddRecipe(NewRecipe);
        int Count = _recipeManager.GetRecipeCount();
        Assert.AreEqual(1, Count);//��������, ��� ���������� ������������� 1 ������������ �������
    }

    //���� ��� �������� ��������� ��������� ���������� ��������
    [Test]
    public void GetRecipeCounts_NoRecipes_ReturnSero()
    {
        int Count = _recipeManager.GetRecipeCount();
        Assert.AreEqual(0, Count);//��������, ��� ���������� ������������� 0

    }


    //���� ��� �������� ��������� ��������� �������� �� ����
    [Test]
    public void GetRecipesByType_MatchingType_ReturnReciresList()
    {

        Recipe NewRecipe = new Recipe { Id = 1, Name = "�����", Type = "�������", Ingredients = new List<string> { "����", "������" }, Difficulty = "������", PreparationTime = 10 };
        Recipe NewRecipe2 = new Recipe { Id = 2, Name = "����� ������", Type = "����", Ingredients = new List<string> { "�����", "������", "����" }, Difficulty = "�������", PreparationTime = 20 };
        _recipeManager.AddRecipe(NewRecipe);
        _recipeManager.AddRecipe(NewRecipe2);
        List<Recipe> searchResult = _recipeManager.GetRecipesByType("�������");
        Assert.Contains(NewRecipe, searchResult);//��������, ��� ������������ ������ � ����� "�������"

    }

    //���� ��� ��������  ��������� �������� �� ��������������� ����
    [Test]
    public void GetRecipesByTypes_NoMatchingType_ReturnEmptyReciresList()
    {

        Recipe NewRecipe = new Recipe { Id = 1, Name = "�����", Type = "�������", Ingredients = new List<string> { "����", "������" }, Difficulty = "������", PreparationTime = 10 };
        _recipeManager.AddRecipe(NewRecipe);
        List<Recipe> searchResult = _recipeManager.GetRecipesByType("����");
        Assert.IsEmpty(searchResult);//��������, ��� ������������ ������ ��� � ����� "����"
    }

    //���� ��� ��������  ��������� �������� �� ������� ����
    [Test]
    public void GetRecipesByType_EmptyType_ThrowException()
    {

        Assert.Throws<Exception>(() => _recipeManager.GetRecipesByType("")); // ��������, ��� ������������� ����������

    }



    //���� ��� �������� ��������� ��������� �������� �� ���������
    [Test]
    public void GetRecipesByDifficulty_MatchingDifficulty_ReturnReciresList()
    {

        Recipe NewRecipe = new Recipe { Id = 1, Name = "�����", Type = "�������", Ingredients = new List<string> { "����", "������" }, Difficulty = "������", PreparationTime = 10 };
        _recipeManager.AddRecipe(NewRecipe);
        List<Recipe> searchResult = _recipeManager.GetRecipesByDifficulty("������");
        Assert.Contains(NewRecipe, searchResult); //��������, ��� ������������ ������ �� ���������� "������"

    }

    //���� ��� ��������  ��������� �������� �� �������������� ���������
    [Test]
    public void GetRecipesByDifficulty_NoMatchingDifficulty_ReturnEmptyReciresList()
    {

        Recipe NewRecipe = new Recipe { Id = 1, Name = "�����", Type = "�������", Ingredients = new List<string> { "����", "������" }, Difficulty = "������", PreparationTime = 10 };
        _recipeManager.AddRecipe(NewRecipe);
        List<Recipe> searchResult = _recipeManager.GetRecipesByDifficulty("�������");
        Assert.IsEmpty(searchResult);//��������, ��� �� ������������ ������ �� ���������� "�������"
    }

    //���� ��� ��������  ��������� �������� �� ������ ���������
    [Test]
    public void GGetRecipesByDifficulty_EmptyAndNullDifficulty_ThrowException()
    {

        Assert.Throws<Exception>(() => _recipeManager.GetRecipesByDifficulty("")); // ��������, ��� ������������� ����������
        Assert.Throws<Exception>(() => _recipeManager.GetRecipesByDifficulty(null)); // ��������, ��� ������������� ����������
    }

    //���� ��� �������� ��������� ��������� �������� �� �������� �������������
    [Test]
    public void GetRecipesByPreparationTime_MatchingPreparationTime_ReturnReciresList()
    {

        Recipe NewRecipe = new Recipe { Id = 1, Name = "�����", Type = "�������", Ingredients = new List<string> { "����", "������" }, Difficulty = "������", PreparationTime = 10 };
        _recipeManager.AddRecipe(NewRecipe);
        List<Recipe> searchResult = _recipeManager.GetRecipesByPreparationTime(10);
        Assert.Contains(NewRecipe, searchResult);//��������, ��� ������������ ������ � �������� ������������� 10 �����

    }

    //���� ��� ��������  ��������� �������� �� ��������������� �������� �������������
    [Test]
    public void GetRecipesByPreparationTime_NoMatchingPreparationTime_ReturnEmptyReciresList()
    {

        Recipe NewRecipe = new Recipe { Id = 1, Name = "�����", Type = "�������", Ingredients = new List<string> { "����", "������" }, Difficulty = "������", PreparationTime = 10 };
        _recipeManager.AddRecipe(NewRecipe);
        List<Recipe> searchResult = _recipeManager.GetRecipesByPreparationTime(5);
        Assert.IsEmpty(searchResult);//��������, ��� �� ������������ ������ � �������� ������������� 5 �����
    }

    //���� ��� ��������  ��������� �������� �� ������� �������� �������������
    [Test]
    public void GetRecipesByPreparationTime_InvalidPreparationTime_ThrowException()
    {

        Assert.Throws<Exception>(() => _recipeManager.GetRecipesByPreparationTime(0)); // ��������, ��� ������������� ����������
        Assert.Throws<Exception>(() => _recipeManager.GetRecipesByPreparationTime(-1)); // ��������, ��� ������������� ����������
    }


}