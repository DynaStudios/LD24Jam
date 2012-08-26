using System;
using System.Collections.Generic;
using System.Xml;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

using DynaStudios.UI.Input;

using DynaStudios.LD24.Game.Entities;
using DynaStudios.LD24.Game.NonEntities;

namespace DynaStudios.LD24.Game
{
    public delegate void EntityPassingDelegate(Entity entity);
    public delegate void ActiveEntityPassingDelegate(ActiveEntity entity);
    public class Map
    {
        public List<Entity> Entities { get; set; }
        public List<ActiveEntity> ActiveEntities { get; set; }

        public Map()
        {
            Entities = new List<Entity>();
            ActiveEntities = new List<ActiveEntity>();
        }

        public void ForEachEntity(EntityPassingDelegate func)
        {
            foreach (Entity entity in Entities)
            {
                func(entity);
            }
            foreach (ActiveEntity entity in ActiveEntities)
            {
                func(entity);
            }
        }

        public void ForEachActiveEntity(ActiveEntityPassingDelegate func)
        {
            foreach (ActiveEntity entity in ActiveEntities)
            {
                func(entity);
            }
        }

        public void ForEachPassiveEntity(EntityPassingDelegate func)
        {
            foreach (Entity entity in Entities)
            {
                func(entity);
            }
        }

        public void SmartAdd(Entity entity)
        {
            ActiveEntity activeEntity = entity as ActiveEntity;
            if (activeEntity != null)
            {
                ActiveEntities.Add(activeEntity);
            }
            else
            {
                Entities.Add(entity);
            }
        }

        public void FullRemove(Entity entity)
        {
            ActiveEntity active = entity as ActiveEntity;
            if (active != null)
            {
                while(ActiveEntities.Remove(active));
            }

            while(Entities.Remove(entity));
        }

        public void Load(string fileName)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(fileName);

            foreach (XmlNode node in doc.DocumentElement.GetElementsByTagName("entity"))
            {
                XmlElement element = node as XmlElement;
                if (node == null) {
                    continue;
                }

                loadEntity(element);
            }
        }

        private void loadEntity(XmlElement element) {
            Position position = GetPosition(element);
            Vector3 rotaion = GetRotation(element);
            XmlElement xmlModel = element.GetElementsByTagName("model")[0] as XmlElement;
            string model = xmlModel.GetAttribute("path");
            float scale = float.Parse(xmlModel.GetAttribute("scale"));

            Entities.Add(new StaticEntity {
                Position = position,
                Direction = rotaion,
                Size = new Vector3(scale, scale, scale),
                ModelName = model
            });
        }

        private Position GetPosition(XmlElement parent)
        {
            XmlElement xmlPosition = parent.GetElementsByTagName("position")[0] as XmlElement;

            Vector3 position = new Vector3(
                    float.Parse(xmlPosition.GetAttribute("x")),
                    float.Parse(xmlPosition.GetAttribute("y")),
                    float.Parse(xmlPosition.GetAttribute("z"))
                );
            return new Position {
                Real = position
            };
        }

        private Vector3 GetRotation(XmlElement parent)
        {
            XmlElement xmlPosition = parent.GetElementsByTagName("rotation")[0] as XmlElement;

            return new Vector3(
                float.Parse(xmlPosition.GetAttribute("x")),
                float.Parse(xmlPosition.GetAttribute("y")),
                float.Parse(xmlPosition.GetAttribute("z"))
            );
        }
    }
}
