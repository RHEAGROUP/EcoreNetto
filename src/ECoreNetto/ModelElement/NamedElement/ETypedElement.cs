﻿// -------------------------------------------------------------------------------------------------
// <copyright file="ETypedElement.cs" company="RHEA System S.A.">
//
//   Copyright 2017 RHEA System S.A.
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace ECoreNetto
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Represents a <see cref="EModelElement"/> with a type
    /// </summary>
    public abstract class ETypedElement : ENamedElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ETypedElement"/> class
        /// </summary>
        /// <param name="resource">
        /// The <see cref="ECoreNetto.Resource.Resource"/> containing all instantiated <see cref="EObject"/>
        /// </param>
        protected ETypedElement(Resource.Resource resource) : base(resource)
        {
            // set the default value
            this.Ordered = true;
            this.Unique = true;
            this.UpperBound = 1;
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="ETypedElement"/> is ordered
        /// </summary>
        public bool Ordered { get; private set; }

        /// <summary>
        /// Gets a value indicating whether this <see cref="ETypedElement"/> is unique
        /// </summary>
        public bool Unique { get; private set; }

        /// <summary>
        /// Gets the lower bound of this <see cref="ETypedElement"/> 
        /// </summary>
        public int LowerBound { get; private set; }

        /// <summary>
        /// Gets the upper bound of this this <see cref="ETypedElement"/>
        /// </summary>
        public int UpperBound { get; private set; }

        /// <summary>
        /// Gets a value indicating whether this <see cref="ETypedElement"/> is many
        /// </summary>
        public bool Many { get; private set; }

        /// <summary>
        /// Gets a value indicating whether this <see cref="ETypedElement"/> is required
        /// </summary>
        public bool Required { get; private set; }

        /// <summary>
        /// Gets the type of this <see cref="ETypedElement"/>
        /// </summary>
        public EClassifier EType { get; private set; }

        /// <summary>
        /// Read the attributes of the current node
        /// </summary>
        internal override void SetProperties()
        {
            base.SetProperties();
            string output;
            if (this.Attributes.TryGetValue("ordered", out output))
            {
                this.Ordered = bool.Parse(output);
            }

            if (this.Attributes.TryGetValue("unique", out output))
            {
                this.Unique = bool.Parse(output);
            }

            if (this.Attributes.TryGetValue("many", out output))
            {
                this.Many = bool.Parse(output);
            }

            if (this.Attributes.TryGetValue("required", out output))
            {
                this.Required = bool.Parse(output);
            }

            if (this.Attributes.TryGetValue("lowerBound", out output))
            {
                this.LowerBound = int.Parse(output);
            }

            if (this.Attributes.TryGetValue("upperBound", out output))
            {
                this.UpperBound = int.Parse(output);
            }

            if (this.Attributes.TryGetValue("eType", out output))
            {
                var typeName = output.Split(' ').Last();

                this.EType = (EClassifier)this.EResource.GetEObject(typeName);
            }
        }
    }
}