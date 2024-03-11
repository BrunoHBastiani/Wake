namespace Wake.Products.Domain.Resources;
public static class ExceptionMessages
{
    //HTTP Messages
    public const string HttpInternalServerError = "Ocorreu um erro interno no servidor durante o processamento. Favor entrar em contato com o suporte para mais informações";

    //Products Messages
    public const string ProductAlreadyExists =
        "Já existe um produto ativo com esse nome";

    public const string ProductDescriptionExceedsMaximumCharacterLimit =
        "Ocorreu um erro interno no servidor durante o processamento. Favor entrar em contato com o suporte para mais informações";

    public const string ProductDoesNotExist =
        "O produto informado não existe";

    public const string ProductFieldNameIsInvalid =
        "O nome do campo informado para busca é inválido. As opções válidas são as seguintes:\r\nId, Name, Description, Price, CreatedAt, UpdatedAt";

    public const string ProductNameBelowMinimumCharacterLimit =
        "O nome do produto precisa ter no mínimo dois caracteres";

    public const string ProductNameExceedsMaximumCharacterLimit =
        "O nome do produto deve ter no máximo cem caracteres";

    public const string ProductNameIsNullOrEmpty =
        "O nome do produto é obrigatório";

    public const string ProductNotCreated =
        "Ocorreu um erro interno na criação do produto. Favor entrar em contato com o suporte para mais informações";

    public const string ProductNotDeleted =
        "Ocorreu um erro interno na exclusão do produto. Favor entrar em contato com o suporte para mais informações";

    public const string ProductNotUpdated =
        "Ocorreu um erro interno na atualização do produto. Favor entrar em contato com o suporte para mais informações";

    public const string ProductOrderIsInvalid =
        "A ordenação informada para busca é inválida. As opções válidas são as seguintes: Asc, Desc";

    public const string ProductPriceIsNegative =
        "O preço do produto não pode ser negativo";

    public const string ProductQuantityIsNegative =
    "O estoque do produto não pode ser negativo";

    public const string ProductIsAlreadyDeactivated =
        "O produto informado já está desativado";
}
