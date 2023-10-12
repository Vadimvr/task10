using DB;
using Models;
using System;
using System.Linq;

namespace BL
{
    internal class UpdateEntity
    {
        private IAppDbContext context;

        public UpdateEntity(IAppDbContext context)
        {
            this.context = context;
        }

        internal void EntitySave(object sender, EventArgs e)
        {

            if (sender is Step)
            {
                Step step = (Step)sender;
                Step old = context.Steps.FirstOrDefault(s => s.ID == step.ID);
                if (old != null)
                {
                    old.ModeID = step.ModeID;
                    old.Timer = step.Timer;
                    old.Destination = step.Destination;
                    old.Speed = step.Speed;
                    old.Type = step.Type;
                    old.Volume = step.Volume;
                }
                else
                {
                    context.Steps.Add(step);

                }
                context.SaveChanges();

            }
            else if (sender is Mode)
            {
                Mode mode = (Mode)sender;
                Mode old = context.Modes.FirstOrDefault(s => s.ID == mode.ID);
                if (old != null)
                {
                    old.Name = mode.Name;
                    old.MaxUsedTips = mode.MaxUsedTips;
                    old.MaxBottleNumber = mode.MaxBottleNumber;
                }
                else
                {
                    context.Modes.Add(mode);

                }
                context.SaveChanges();

            }
            else
            {
                throw new ArgumentNullException(nameof(sender));
            }
        }
    }
}
