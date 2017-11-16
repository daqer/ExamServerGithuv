namespace ExamServer.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TournamentFrameWork : DbContext
    {
        public TournamentFrameWork()
            : base("name=TournamentFrameWork")
        {
        }

        public virtual DbSet<TblAnswer> TblAnswer { get; set; }
        public virtual DbSet<tblJudge> TblJudge { get; set; }
        public virtual DbSet<tblProject> TblProject { get; set; }
        public virtual DbSet<tblQuestionaire> TblQuestionaire { get; set; }
        public virtual DbSet<tblTeam> TblTeam { get; set; }
        public virtual DbSet<tblTournament> TblTournament { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tblJudge>()
                .Property(e => e.fldJudgeLetter)
                .IsUnicode(false);

            modelBuilder.Entity<tblJudge>()
                .Property(e => e.fldPassword)
                .IsUnicode(false);

            modelBuilder.Entity<tblProject>()
                .Property(e => e.fldProjectName)
                .IsUnicode(false);

            modelBuilder.Entity<tblProject>()
                .Property(e => e.fldDescription)
                .IsUnicode(false);

            modelBuilder.Entity<tblProject>()
                .Property(e => e.fldReport)
                .IsUnicode(false);

            modelBuilder.Entity<tblQuestionaire>()
                .Property(e => e.fldFirstQuestion)
                .IsUnicode(false);

            modelBuilder.Entity<tblQuestionaire>()
                .Property(e => e.fldSecondQuestion)
                .IsUnicode(false);

            modelBuilder.Entity<tblQuestionaire>()
                .Property(e => e.fldThirdQuestion)
                .IsUnicode(false);

            modelBuilder.Entity<tblQuestionaire>()
                .Property(e => e.fldFourthQuestion)
                .IsUnicode(false);

            modelBuilder.Entity<tblTeam>()
                .Property(e => e.fldTeamName)
                .IsUnicode(false);

            modelBuilder.Entity<tblTeam>()
                .Property(e => e.fldPassword)
                .IsUnicode(false);

            modelBuilder.Entity<tblTeam>()
                .Property(e => e.fldTopic)
                .IsUnicode(false);

            modelBuilder.Entity<tblTeam>()
                .Property(e => e.fldLeaderName)
                .IsUnicode(false);

            modelBuilder.Entity<tblTournament>()
                .Property(e => e.fldTournamentName)
                .IsUnicode(false);

            modelBuilder.Entity<tblTournament>()
                .Property(e => e.fldStartTime)
                .IsUnicode(false);

            modelBuilder.Entity<tblTournament>()
                .Property(e => e.fldAddress)
                .IsUnicode(false);
        }
    }
}
