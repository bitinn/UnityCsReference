using System.Collections.Generic;

namespace UnityEngine.UIElements
{
    public abstract class MouseManipulator : Manipulator
    {
        public List<ManipulatorActivationFilter> activators { get; private set; }
        private ManipulatorActivationFilter m_currentActivator;

        protected MouseManipulator()
        {
            activators = new List<ManipulatorActivationFilter>();
        }

        protected bool CanStartManipulation(IMouseEvent e)
        {
            foreach (var activator in activators)
            {
                if (activator.Matches(e))
                {
                    m_currentActivator = activator;
                    return true;
                }
            }

            return false;
        }

        protected bool CanStopManipulation(IMouseEvent e)
        {
            if (e == null)
            {
                return false;
            }

            return ((MouseButton)e.button == m_currentActivator.button);
        }
    }
}