namespace NewEva.StyleHelper.Transitions
{
    public interface IZIndexController
    {
        void Stack(params TransitionerSlide[] highestToLowest);
    }
}