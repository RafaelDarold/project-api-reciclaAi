using Microsoft.EntityFrameworkCore;
using project_api_reciclaAi.Models;

namespace project_api_reciclaAi.DataContexts
{
    public class ReciclaAIContext : DbContext
    {
        public ReciclaAIContext(DbContextOptions<ReciclaAIContext> options) : base(options) { }

        public DbSet<TipoUsuario> TipoUsuario { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<TipoMaterial> TipoMaterial { get; set; }
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<EquipeColeta> EquipeColeta { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<ClienteEndereco> ClienteEndereco { get; set; }
        public DbSet<Catador> Catador { get; set; }
        public DbSet<Solicitacao> Solicitacao { get; set; }
        public DbSet<SolicitacaoTipoMaterial> SolicitacaoTipoMaterial { get; set; }
        public DbSet<Foto> Foto { get; set; }
        public DbSet<Coleta> Coleta { get; set; }
        public DbSet<Avaliacao> Avaliacao { get; set; }
        public DbSet<ColetaTipoMaterial> ColetaTipoMaterial { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.ToTable("Tipo_Usuario");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.NivelAcesso)
                    .IsRequired();
            });

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

            modelBuilder.Entity<TipoMaterial>(entity =>
            {
                entity.ToTable("Tipo_Material");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Nome).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Descricao).HasColumnType("TEXT");
                entity.Property(e => e.TipoPeso).IsRequired().HasMaxLength(50);
                entity.Property(e => e.CriadoEm).IsRequired();
                entity.Property(e => e.AtualizadoEm).IsRequired();
            });

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
                    .WithMany(t => t.Empresa)
                    .HasForeignKey(e => e.TipoUsuarioId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<EquipeColeta>(entity =>
            {
                entity.ToTable("Equipe_Coleta");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Status).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Nome).IsRequired().HasMaxLength(100);

                entity.HasOne(e => e.Empresa)
                    .WithMany(emp => emp.EquipeColeta)
                    .HasForeignKey(e => e.EmpresaId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

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
                    .WithMany(t => t.Cliente)
                    .HasForeignKey(e => e.TipoUsuarioId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<ClienteEndereco>(entity =>
            {
                entity.ToTable("Cliente_Endereco");
                entity.HasKey(e => e.Id);

                entity.HasOne(e => e.Cliente)
                    .WithMany(c => c.Endereco)
                    .HasForeignKey(e => e.ClienteId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.Endereco)
                    .WithMany(end => end.ClienteEndereco)
                    .HasForeignKey(e => e.EnderecoId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

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
                    .WithMany(t => t.Catador)
                    .HasForeignKey(e => e.TipoUsuarioId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.EquipeColeta)
                    .WithMany(eq => eq.Catador)
                    .HasForeignKey(e => e.EquipeColetaId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

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
                    .WithMany(c => c.Solicitacao)
                    .HasForeignKey(e => e.ClienteId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Endereco)
                    .WithMany(end => end.Solicitacao)
                    .HasForeignKey(e => e.EnderecoId)
                    .OnDelete(DeleteBehavior.Restrict);

                // Nullable — solicitação pode existir sem equipe ainda
                entity.HasOne(e => e.EquipeColeta)
                    .WithMany(eq => eq.Solicitacao)
                    .HasForeignKey(e => e.EquipeColetaId)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.SetNull);

                // Nullable — solicitação pode existir sem catador ainda
                entity.HasOne(e => e.Catador)
                    .WithMany(c => c.Solicitacao)
                    .HasForeignKey(e => e.CatadorId)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<SolicitacaoTipoMaterial>(entity =>
            {
                entity.ToTable("Solicitacao_Tipo_Material");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Quantidade)
                    .IsRequired()
                    .HasColumnType("DECIMAL(10,2)");

                entity.HasOne(e => e.Solicitacao)
                    .WithMany(s => s.TipoMaterial)
                    .HasForeignKey(e => e.SolicitacaoId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.TipoMaterial)
                    .WithMany(t => t.SolicitacaoMaterial)
                    .HasForeignKey(e => e.TipoMaterialId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Foto>(entity =>
            {
                entity.ToTable("Foto");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Url).IsRequired().HasMaxLength(255);

                entity.HasOne(e => e.Solicitacao)
                    .WithMany(s => s.Foto)
                    .HasForeignKey(e => e.SolicitacaoId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

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
                    .WithMany(s => s.Coleta)
                    .HasForeignKey(e => e.SolicitacaoId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Avaliacao>(entity =>
            {
                entity.ToTable("Avaliacao");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.SatisfacaoColeta).IsRequired();
                entity.Property(e => e.Observacao).HasColumnType("TEXT");

                entity.HasOne(e => e.Coleta)
                    .WithMany(c => c.Avaliacao)
                    .HasForeignKey(e => e.ColetaId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Cliente)
                    .WithMany(c => c.Avaliacao)
                    .HasForeignKey(e => e.ClienteId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<ColetaTipoMaterial>(entity =>
            {
                entity.ToTable("Coleta_Tipo_Material");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Quantidade)
                    .IsRequired()
                    .HasColumnType("DECIMAL(10,2)");

                entity.HasOne(e => e.Coleta)
                    .WithMany(c => c.TipoMaterial)
                    .HasForeignKey(e => e.ColetaId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.TipoMaterial)
                    .WithMany(t => t.ColetaMaterial)
                    .HasForeignKey(e => e.TipoMaterialId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}