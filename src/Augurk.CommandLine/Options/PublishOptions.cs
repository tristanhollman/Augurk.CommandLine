﻿/*
 Copyright 2017, Augurk
 
 Licensed under the Apache License, Version 2.0 (the "License");
 you may not use this file except in compliance with the License.
 You may obtain a copy of the License at
 
 http://www.apache.org/licenses/LICENSE-2.0
 
 Unless required by applicable law or agreed to in writing, software
 distributed under the License is distributed on an "AS IS" BASIS,
 WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 See the License for the specific language governing permissions and
 limitations under the License.
*/

using System.Collections.Generic;
using CommandLine;

namespace Augurk.CommandLine.Options
{
    /// <summary>
    /// Represents the available command line options when publishing features.
    /// </summary>
    [Verb(VERB_NAME, HelpText = "Publish features to Augurk.")]
    internal class PublishOptions : SharedOptions
    {
        /// <summary>
        /// Name of the verb for this set of options.
        /// </summary>
        public const string VERB_NAME = "publish";

        /// <summary>
        /// Gets or sets the set of comma separated .feature file or directory specifications that should be published to Augurk.
        /// </summary>
        [Option("featureFiles", Separator = ',', HelpText = "Comma separated set of feature file or directory specifications that should be published to Augurk. Also supports * or ? wildcard characters for file specifications and directory names (will automatically search for *.feature within that directory)", Required = true)]
        public IEnumerable<string> FeatureFiles { get; set; }

        /// <summary>
        /// Gets or sets the name of the product under which the feature files should be published.
        /// </summary>
        [Option("productName", HelpText = "Name of the product under which the feature files should be published. Cannot be used in combination with the --branchName option.", SetName = "product", Required = false)]
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the filename of the Markdown file that should be uploaded as the product page.
        /// </summary>
        [Option("productDesc", HelpText = "Optional path to a Markdown file containing the product page for the specified product.", Required = false)]
        public string ProductDescription { get; set; }

        /// <summary>
        /// Gets or sets the name of the group under which the feature files should be published.
        /// </summary>
        [Option("groupName", HelpText = "Name of the group under which the feature files should be published.", Required = true)]
        public string GroupName { get; set; }

        /// <summary>
        /// Gets or sets the name of the branch under which the feature files should be published.
        /// </summary>
        [Option("branchName", HelpText = "Name of the branch under which the feature files should be published. Cannot be used in combination with the --productName option.", SetName = "branch", Required = false)]
        public string BranchName { get; set; }

        /// <summary>
        /// Gets or sets the version of the feature files that are being published.
        /// </summary>
        [Option("version", HelpText = "Version of the feature files that should be published. Cannot be used in combination with the --clearGroup option.", SetName = "product", Required = false)]
        public string Version { get; set; } = "0.0.0";

        /// <summary>
        /// Gets or sets a value indicating whether the group should be cleared prior to publishing the new features.
        /// </summary>
        [Option("clearGroup", HelpText = "If set the group specified by --groupName will be cleared prior to publishing the new features. Cannot be used in combination with the --version option.", SetName = "branch", Required = false)]
        public bool ClearGroup { get; set; }

        /// <summary>
        /// Gets or sets the language in which the feature files have been written.
        /// </summary>
        [Option("language", HelpText = "Language in which the features files have been written. For example: `en-US` or `nl-NL`.", Required = false)]
        public string Language { get; set; } = "en-US";

        /// <summary>
        /// Gets or sets a value indicating whether local imaages should be embedded in the feature.
        /// </summary>
        [Option("embed", HelpText = "If set any image references to local files will be replaced by an embedded instance of that image.")]
        public bool Embed { get; set; }
    }
}
