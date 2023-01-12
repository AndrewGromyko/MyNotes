using MyNotes.Persistence;

namespace MyNotes.Tests.Common
{
    public abstract class TestCommandBase : IDisposable
    {
        protected readonly NotesDbContext Context;

        public TestCommandBase()
        {
            Context = MyNotesContextFactory.Create();
        }

        public void Dispose()
        {
            MyNotesContextFactory.Destroy(Context);
        }
    }
}
