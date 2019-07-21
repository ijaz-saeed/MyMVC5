//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Data.Entity.Infrastructure.MappingViews;

[assembly: DbMappingViewCacheTypeAttribute(
    typeof(WebMvc5.Models.BlogDbContext),
    typeof(Edm_EntityMappingGeneratedViews.ViewsForBaseEntitySets8aaacc7c427dc71b51c51a5f37a9368ea0c239df9409420d5a8e4da87bf86e94))]

namespace Edm_EntityMappingGeneratedViews
{
    using System;
    using System.CodeDom.Compiler;
    using System.Data.Entity.Core.Metadata.Edm;

    /// <summary>
    /// Implements a mapping view cache.
    /// </summary>
    [GeneratedCode("Entity Framework 6 Power Tools", "0.9.2.0")]
    internal sealed class ViewsForBaseEntitySets8aaacc7c427dc71b51c51a5f37a9368ea0c239df9409420d5a8e4da87bf86e94 : DbMappingViewCache
    {
        /// <summary>
        /// Gets a hash value computed over the mapping closure.
        /// </summary>
        public override string MappingHashValue
        {
            get { return "8aaacc7c427dc71b51c51a5f37a9368ea0c239df9409420d5a8e4da87bf86e94"; }
        }

        /// <summary>
        /// Gets a view corresponding to the specified extent.
        /// </summary>
        /// <param name="extent">The extent.</param>
        /// <returns>The mapping view, or null if the extent is not associated with a mapping view.</returns>
        public override DbMappingView GetView(EntitySetBase extent)
        {
            if (extent == null)
            {
                throw new ArgumentNullException("extent");
            }

            var extentName = extent.EntityContainer.Name + "." + extent.Name;

            if (extentName == "CodeFirstDatabase.Blog")
            {
                return GetView0();
            }

            if (extentName == "CodeFirstDatabase.Post")
            {
                return GetView1();
            }

            if (extentName == "BlogDbContext.Blogs")
            {
                return GetView2();
            }

            if (extentName == "BlogDbContext.Posts")
            {
                return GetView3();
            }

            return null;
        }

        /// <summary>
        /// Gets the view for CodeFirstDatabase.Blog.
        /// </summary>
        /// <returns>The mapping view.</returns>
        private static DbMappingView GetView0()
        {
            return new DbMappingView(@"
    SELECT VALUE -- Constructing Blog
        [CodeFirstDatabaseSchema.Blog](T1.Blog_Id, T1.Blog_Url, T1.Blog_Description, T1.Blog_RowVersion)
    FROM (
        SELECT 
            T.Id AS Blog_Id, 
            T.Url AS Blog_Url, 
            T.Description AS Blog_Description, 
            T.RowVersion AS Blog_RowVersion, 
            True AS _from0
        FROM BlogDbContext.Blogs AS T
    ) AS T1");
        }

        /// <summary>
        /// Gets the view for CodeFirstDatabase.Post.
        /// </summary>
        /// <returns>The mapping view.</returns>
        private static DbMappingView GetView1()
        {
            return new DbMappingView(@"
    SELECT VALUE -- Constructing Post
        [CodeFirstDatabaseSchema.Post](T1.Post_Id, T1.Post_Title, T1.Post_DateCreated, T1.Post_Content, T1.Post_BlogId)
    FROM (
        SELECT 
            T.Id AS Post_Id, 
            T.Title AS Post_Title, 
            T.DateCreated AS Post_DateCreated, 
            T.Content AS Post_Content, 
            T.BlogId AS Post_BlogId, 
            True AS _from0
        FROM BlogDbContext.Posts AS T
    ) AS T1");
        }

        /// <summary>
        /// Gets the view for BlogDbContext.Blogs.
        /// </summary>
        /// <returns>The mapping view.</returns>
        private static DbMappingView GetView2()
        {
            return new DbMappingView(@"
    SELECT VALUE -- Constructing Blogs
        [WebMvc5.Models.Blog](T1.Blog_Id, T1.Blog_Url, T1.Blog_Description, T1.Blog_RowVersion)
    FROM (
        SELECT 
            T.Id AS Blog_Id, 
            T.Url AS Blog_Url, 
            T.Description AS Blog_Description, 
            T.RowVersion AS Blog_RowVersion, 
            True AS _from0
        FROM CodeFirstDatabase.Blog AS T
    ) AS T1");
        }

        /// <summary>
        /// Gets the view for BlogDbContext.Posts.
        /// </summary>
        /// <returns>The mapping view.</returns>
        private static DbMappingView GetView3()
        {
            return new DbMappingView(@"
    SELECT VALUE -- Constructing Posts
        [WebMvc5.Models.Post](T1.Post_Id, T1.Post_Title, T1.Post_DateCreated, T1.Post_Content, T1.Post_BlogId)
    FROM (
        SELECT 
            T.Id AS Post_Id, 
            T.Title AS Post_Title, 
            T.DateCreated AS Post_DateCreated, 
            T.Content AS Post_Content, 
            T.BlogId AS Post_BlogId, 
            True AS _from0
        FROM CodeFirstDatabase.Post AS T
    ) AS T1");
        }
    }
}