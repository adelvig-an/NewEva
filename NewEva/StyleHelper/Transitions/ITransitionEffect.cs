using System.Windows;
using System.Windows.Media.Animation;

namespace NewEva.StyleHelper.Transitions
{
    public interface ITransitionEffect
    {
        Timeline Build<TSubject>(TSubject effectSubject) where TSubject : FrameworkElement, ITransitionEffectSubject;
    }
}