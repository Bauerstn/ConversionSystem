using Microsoft.OpenApi;

namespace ConversionSystem.API.Infrastructures
{
    static internal class DocumentExtensions
    {
        public static void GetSwaggerDocument(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("Product", new OpenApiInfo { Title = "Сущность товара", Version = "v1" });
                c.SwaggerDoc("ProductPresentation", new OpenApiInfo { Title = "Сущность товара в оформлении", Version = "v1" });
                c.SwaggerDoc("ReportResult", new OpenApiInfo { Title = "Сущность отчета", Version = "v1" });

                var filePath = Path.Combine(AppContext.BaseDirectory, "ConversionSystem.API.xml");
                c.IncludeXmlComments(filePath);
            });
        }

        public static void GetSwaggerDocumnetUI(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint("Product/swagger.json", "Товары");
                x.SwaggerEndpoint("ProductPresentation/swagger.json", "Товары в оформлении");
                x.SwaggerEndpoint("ReportResult/swagger.json", "Отчеты");
            });
        }
    }
}
