﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Wake.Products.Domain.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class ExceptionMessages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ExceptionMessages() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Wake.Products.Domain.Resources.ExceptionMessages", typeof(ExceptionMessages).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Ocorreu um erro interno no servidor durante o processamento. Favor entrar em contato com o suporte para mais informações.
        /// </summary>
        public static string HttpInternalServerError {
            get {
                return ResourceManager.GetString("HttpInternalServerError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Já existe um produto ativo com essas caracteristicas.
        /// </summary>
        public static string ProductAlreadyExists {
            get {
                return ResourceManager.GetString("ProductAlreadyExists", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A descrição do produto deve ter no máximo duzentos caracteres.
        /// </summary>
        public static string ProductDescriptionExceedsMaximumCharacterLimit {
            get {
                return ResourceManager.GetString("ProductDescriptionExceedsMaximumCharacterLimit", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to O produto informado não existe.
        /// </summary>
        public static string ProductDoesNotExist {
            get {
                return ResourceManager.GetString("ProductDoesNotExist", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to O nome do campo informado para busca é inválido. As opções válidas são as seguintes:
        ///Id, Name, Description, Price, CreatedAt, UpdatedAt.
        /// </summary>
        public static string ProductFieldNameIsInvalid {
            get {
                return ResourceManager.GetString("ProductFieldNameIsInvalid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to O nome do produto precisa ter no mínimo dois caracteres.
        /// </summary>
        public static string ProductNameBelowMinimumCharacterLimit {
            get {
                return ResourceManager.GetString("ProductNameBelowMinimumCharacterLimit", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to O nome do produto deve ter no máximo cem caracteres.
        /// </summary>
        public static string ProductNameExceedsMaximumCharacterLimit {
            get {
                return ResourceManager.GetString("ProductNameExceedsMaximumCharacterLimit", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to O nome do produto é obrigatório.
        /// </summary>
        public static string ProductNameIsNullorEmpty {
            get {
                return ResourceManager.GetString("ProductNameIsNullorEmpty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Ocorreu um erro interno na criação do produto. Favor entrar em contato com o suporte para mais informações.
        /// </summary>
        public static string ProductNotCreated {
            get {
                return ResourceManager.GetString("ProductNotCreated", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Ocorreu um erro interno na exclusão do produto. Favor entrar em contato com o suporte para mais informações.
        /// </summary>
        public static string ProductNotDeleted {
            get {
                return ResourceManager.GetString("ProductNotDeleted", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Ocorreu um erro interno na atualização do produto. Favor entrar em contato com o suporte para mais informações.
        /// </summary>
        public static string ProductNotUpdated {
            get {
                return ResourceManager.GetString("ProductNotUpdated", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A ordenação informada para busca é inválida. As opções válidas são as seguintes:
        ///Asc, Desc.
        /// </summary>
        public static string ProductOrderIsInvalid {
            get {
                return ResourceManager.GetString("ProductOrderIsInvalid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to O preço do produto não pode ser negativo.
        /// </summary>
        public static string ProductPriceIsNegative {
            get {
                return ResourceManager.GetString("ProductPriceIsNegative", resourceCulture);
            }
        }
    }
}
