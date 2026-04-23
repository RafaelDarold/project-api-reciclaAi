using Microsoft.EntityFrameworkCore;
using project_api_reciclaAi.Models;

namespace project_api_reciclaAi.DataContexts
{
    public class ReciclaAIContext : DbContext
    {
        public ReciclaAIContext(DbContextOptions<ReciclaAIContext> options) : base(options) { }

        // =============================================
        // DbSets — um por tabela do banco
        // =============================================
        public DbSet<TipoUsuario> TiposUsuario { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<TipoMaterial> TiposMaterial { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<EquipeColeta> EquipesColeta { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<ClienteEndereco> ClientesEndereco { get; set; }
        public DbSet<Catador> Catadores { get; set; }
        public DbSet<Solicitacao> Solicitacoes { get; set; }
        public DbSet<SolicitacaoTipoMaterial> SolicitacoesTipoMaterial { get; set; }
        public DbSet<Foto> Fotos { get; set; }
        public DbSet<Coleta> Coletas { get; set; }
        public DbSet<Avaliacao> Avaliacoes { get; set; }
        public DbSet<ColetaTipoMaterial> ColetasTipoMaterial { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // =============================================
            // TipoUsuario
            // =============================================
            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.ToTable("TipoUsuario");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.NivelAcesso)
                    .IsRequired();
            });

            // =============================================
            // Endereco
            // =============================================
            modelBuilder.Entity<Endereco>(entity =>
            {
                entity.ToTable("Endereco");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Cep).IsRequired().HasMaxLength(10);
                entity.Property(e => e.Estado).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Numero).IsRequired().HasMaxLength(10);
                entity.Property(e => e.Pais).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Rua).IsRequired().HasMaxLength(150);
                entity.Property(e => e.Bairro).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Cidade).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Observacao).HasColumnType("TEXT");
            });

            // =============================================
            // TipoMaterial
            // =============================================
            modelBuilder.Entity<TipoMaterial>(entity =>
            {
                entity.ToTable("TipoMaterial");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Nome).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Descricao).HasColumnType("TEXT");
                entity.Property(e => e.TipoPeso).IsRequired().HasMaxLength(50);
                entity.Property(e => e.CriadoEm).IsRequired();
                entity.Property(e => e.AtualizadoEm).IsRequired();
            });

            // =============================================
            // Empresa
            // =============================================
            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.ToTable("Empresa");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Email).IsRequired().HasMaxLength(150);
                entity.Property(e => e.Senha).IsRequired().HasMaxLength(255);
                entity.Property(e => e.Telefone).IsRequired().HasMaxLength(20);
                entity.Property(e => e.Responsavel).IsRequired().HasMaxLength(150);
                entity.Property(e => e.Cnpj).IsRequired().HasMaxLength(20);
                entity.Property(e => e.RazaoSocial).IsRequired().HasMaxLength(150);

                entity.HasIndex(e => e.Email).IsUnique();
                entity.HasIndex(e => e.Cnpj).IsUnique();

                entity.HasOne(e => e.TipoUsuario)
                    .WithMany(t => t.Empresas)
                    .HasForeignKey(e => e.TipoUsuarioId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // =============================================
            // EquipeColeta
            // =============================================
            modelBuilder.Entity<EquipeColeta>(entity =>
            {
                entity.ToTable("EquipeColeta");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Status).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Nome).IsRequired().HasMaxLength(100);

                entity.HasOne(e => e.Empresa)
                    .WithMany(emp => emp.EquipesColeta)
                    .HasForeignKey(e => e.EmpresaId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // =============================================
            // Cliente
            // =============================================
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("Cliente");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.CpfCnpj).IsRequired().HasMaxLength(20);
                entity.Property(e => e.Foto).IsRequired().HasMaxLength(255);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(150);
                entity.Property(e => e.Senha).IsRequired().HasMaxLength(255);
                entity.Property(e => e.Responsavel).IsRequired().HasMaxLength(150);
                entity.Property(e => e.Telefone).IsRequired().HasMaxLength(20);
                entity.Property(e => e.Nome).IsRequired().HasMaxLength(150);
                entity.Property(e => e.TipoPessoa).IsRequired().HasMaxLength(20);

                entity.HasIndex(e => e.Email).IsUnique();
                entity.HasIndex(e => e.CpfCnpj).IsUnique();

                entity.HasOne(e => e.TipoUsuario)
                    .WithMany(t => t.Clientes)
                    .HasForeignKey(e => e.TipoUsuarioId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // =============================================
            // ClienteEndereco — tabela de junção N:N
            // =============================================
            modelBuilder.Entity<ClienteEndereco>(entity =>
            {
                entity.ToTable("ClienteEndereco");
                entity.HasKey(e => e.Id);

                entity.HasOne(e => e.Cliente)
                    .WithMany(c => c.Enderecos)
                    .HasForeignKey(e => e.ClienteId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.Endereco)
                    .WithMany(end => end.ClientesEndereco)
                    .HasForeignKey(e => e.EnderecoId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // =============================================
            // Catador
            // =============================================
            modelBuilder.Entity<Catador>(entity =>
            {
                entity.ToTable("Catador");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.CpfCnpj).IsRequired().HasMaxLength(20);
                entity.Property(e => e.Senha).IsRequired().HasMaxLength(255);
                entity.Property(e => e.Telefone).IsRequired().HasMaxLength(20);
                entity.Property(e => e.Foto).IsRequired().HasMaxLength(255);
                entity.Property(e => e.Nome).IsRequired().HasMaxLength(150);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(150);

                entity.HasIndex(e => e.Email).IsUnique();
                entity.HasIndex(e => e.CpfCnpj).IsUnique();

                entity.HasOne(e => e.TipoUsuario)
                    .WithMany(t => t.Catadores)
                    .HasForeignKey(e => e.TipoUsuarioId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.EquipeColeta)
                    .WithMany(eq => eq.Catadores)
                    .HasForeignKey(e => e.EquipeColetaId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // =============================================
            // Solicitacao
            // =============================================
            modelBuilder.Entity<Solicitacao>(entity =>
            {
                entity.ToTable("Solicitacao");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.DataSolicitacao).IsRequired();
                entity.Property(e => e.VolumeEstimado)
                    .IsRequired()
                    .HasColumnType("DECIMAL(10,2)");
                entity.Property(e => e.Observacao).HasColumnType("TEXT");
                entity.Property(e => e.Status).IsRequired().HasMaxLength(50);

                entity.HasOne(e => e.Cliente)
                    .WithMany(c => c.Solicitacoes)
                    .HasForeignKey(e => e.ClienteId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Endereco)
                    .WithMany(end => end.Solicitacoes)
                    .HasForeignKey(e => e.EnderecoId)
                    .OnDelete(DeleteBehavior.Restrict);

                // Nullable — solicitação pode existir sem equipe ainda
                entity.HasOne(e => e.EquipeColeta)
                    .WithMany(eq => eq.Solicitacoes)
                    .HasForeignKey(e => e.EquipeColetaId)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.SetNull);

                // Nullable — solicitação pode existir sem catador ainda
                entity.HasOne(e => e.Catador)
                    .WithMany(c => c.Solicitacoes)
                    .HasForeignKey(e => e.CatadorId)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            // =============================================
            // SolicitacaoTipoMaterial — tabela de junção N:N
            // =============================================
            modelBuilder.Entity<SolicitacaoTipoMaterial>(entity =>
            {
                entity.ToTable("SolicitacaoTipoMaterial");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Quantidade)
                    .IsRequired()
                    .HasColumnType("DECIMAL(10,2)");

                entity.HasOne(e => e.Solicitacao)
                    .WithMany(s => s.TiposMaterial)
                    .HasForeignKey(e => e.SolicitacaoId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.TipoMaterial)
                    .WithMany(t => t.SolicitacoesMaterial)
                    .HasForeignKey(e => e.TipoMaterialId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // =============================================
            // Foto
            // =============================================
            modelBuilder.Entity<Foto>(entity =>
            {
                entity.ToTable("Foto");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Url).IsRequired().HasMaxLength(255);

                entity.HasOne(e => e.Solicitacao)
                    .WithMany(s => s.Fotos)
                    .HasForeignKey(e => e.SolicitacaoId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // =============================================
            // Coleta
            // =============================================
            modelBuilder.Entity<Coleta>(entity =>
            {
                entity.ToTable("Coleta");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.DataColeta).IsRequired();
                entity.Property(e => e.Status).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Observacao).HasColumnType("TEXT");
                entity.Property(e => e.PesoTotal)
                    .IsRequired()
                    .HasColumnType("DECIMAL(10,2)");
                entity.Property(e => e.HoraColeta).IsRequired();

                entity.HasOne(e => e.Solicitacao)
                    .WithMany(s => s.Coletas)
                    .HasForeignKey(e => e.SolicitacaoId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // =============================================
            // Avaliacao
            // =============================================
            modelBuilder.Entity<Avaliacao>(entity =>
            {
                entity.ToTable("Avaliacao");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.SatisfacaoColeta).IsRequired();
                entity.Property(e => e.Observacao).HasColumnType("TEXT");

                entity.HasOne(e => e.Coleta)
                    .WithMany(c => c.Avaliacoes)
                    .HasForeignKey(e => e.ColetaId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Cliente)
                    .WithMany(c => c.Avaliacoes)
                    .HasForeignKey(e => e.ClienteId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // =============================================
            // ColetaTipoMaterial — tabela de junção N:N
            // =============================================
            modelBuilder.Entity<ColetaTipoMaterial>(entity =>
            {
                entity.ToTable("ColetaTipoMaterial");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Quantidade)
                    .IsRequired()
                    .HasColumnType("DECIMAL(10,2)");

                entity.HasOne(e => e.Coleta)
                    .WithMany(c => c.TiposMaterial)
                    .HasForeignKey(e => e.ColetaId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.TipoMaterial)
                    .WithMany(t => t.ColetasMaterial)
                    .HasForeignKey(e => e.TipoMaterialId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}